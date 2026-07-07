import { API_BASE_URL } from "../../../utils/constants";
import "./LoginPage.css";
import { useState } from "react";

export default function Login() {
  const [email, setEmail] = useState("");
  const [pwd, setPwd] = useState("");
  const [error, setError] = useState({});

  const handleSubmit = async (e) => {
    e.preventDefault();
    const newError = {};
    if (email === "") {
      newError.email = "Email is mandatory. Please provide the email";
    }
    if (pwd === "") {
      newError.password = "Password is mandatory. Please provide the password.";
    }

    setError(newError);

    // call the submit logic only if we do not have any validation error
    if (Object.keys(newError).length === 0) {
      const loginUri = API_BASE_URL + "/api/Auth/Login";
      try {
        // calling the login api to validate the credentials
        const resp = await fetch(loginUri, {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
            emailId: email,
            password: pwd,
          }),
        });

        if (!resp.Ok) {
          setError({ error: "Login failed for the user" });
          return;
        }

        const userData = resp.json();

        console.log(userData);
      } catch (err) {
        setError({ error: err.message });
      }
    }
  };

  const handleSSO = () => {
    console.log("SSO handler called");
  };

  const handleForgetPwd = () => {
    console.log("forget password handler called");
  };

  return (
    <div>
      <div className="login-page-container">
        <div className="container--left"></div>
        <div className="container--right">
          <form className="right--form" onSubmit={(e) => handleSubmit(e)}>
            <div>
              <div className="form-title--primary">Sign in to your account</div>
              <div className="form-title--secondary">
                Enter your work email and password to continue
              </div>
            </div>
            <div className="form--fields">
              <label htmlFor="email">
                Work email<span>*</span>
              </label>
              <input
                className="form-input"
                id="email"
                type="email"
                placeholder="Enter your work email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              ></input>
              {!email && (
                <div className="error-msg" aria-live="polite">
                  {error.email}
                </div>
              )}
            </div>
            <div className="form--fields">
              <label htmlFor="pwd">
                Password<span>*</span>
              </label>
              <input
                className="form-input"
                id="pwd"
                type="password"
                value={pwd}
                onChange={(e) => setPwd(e.target.value)}
                placeholder="Enter your password"
              ></input>
              {!pwd && (
                <div className="error-msg" aria-live="polite">
                  {error.password}
                </div>
              )}
            </div>
            <div className="form-field--forgetPwd" onClick={handleForgetPwd}>
              Forgot password ?
            </div>
            {/* type="submit" triggers the handler attached to form  */}
            <button className="form--btn" type="submit">
              Sign in
            </button>
            <div className="line-break">
              <span>or</span>
            </div>
            {/* type="button" does not trigger the form submission automatically */}
            <button className="form--btn" type="button" onClick={handleSSO}>
              Continue with SSO
            </button>
          </form>
        </div>
      </div>
    </div>
  );
}
