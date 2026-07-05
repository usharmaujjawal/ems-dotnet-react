import "./LoginPage.css";

export default function Login() {
  return (
    <div>
      <div className="login-page-container">
        <div className="container--left">LeftSide</div>
        <div className="container--right">
          <div className="right--form">
            <div>
              <div className="form-title--primary">Sign in to your account</div>
              <div className="form-title--secondary">
                Enter your work email and password to continue
              </div>
            </div>
            <div className="form--fields">
              <label htmlFor="email">Work email</label>
              <input
                className="form-input"
                id="email"
                type="text"
                placeholder="Enter your work email"
              ></input>
            </div>
            <div className="form--fields">
              <label htmlFor="pwd">Password</label>
              <input
                className="form-input"
                id="pwd"
                type="password"
                placeholder="Enter your password"
              ></input>
            </div>
            <div className="form-field--forgetPwd">Forgot password ?</div>
            <button className="form--btn">Sign in</button>
            <div className="line-break">
              <span>or</span>
            </div>
            <button className="form--btn">Continue with SSO</button>
          </div>
        </div>
      </div>
    </div>
  );
}
