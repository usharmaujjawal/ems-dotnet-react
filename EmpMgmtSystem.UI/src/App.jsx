import "./assets/styles/global.css";

import Login from "./pages/Auth/Login/LoginPage";

import Dashboard from "./pages/Dashboard/Dashboard";

import Employees from "./pages/Employees/Employees";

import { BrowserRouter, Routes, Route } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/dashboard" element={<Dashboard />} />
        <Route path="/employees" element={<Employees />}></Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
