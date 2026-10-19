import "./Dashboard.css";
import { Apps24Regular } from "@fluentui/react-icons";
import {
  CalendarCheckmark24Regular,
  PersonCircle24Regular,
  Building24Regular,
  Clock24Regular,
  Beach24Regular,
  MoneyHand24Regular,
  Laptop24Regular,
  Star24Regular,
  Briefcase24Regular,
  AlertBadge24Regular,
} from "@fluentui/react-icons";

function Dashboard() {
  const currDate = new Date().toDateString();
  const empName = "Alex Dev";
  const role = "Admin";

  return (
    <div className="dashboard-page-container">
      <div className="left-panel">
        <div className="left-panel--header">
          <span className="icon-filled"></span>
          <span>EmpManage</span>
        </div>

        <div className="left-panel--options">
          <div className="options--section">
            <div className="left-panel--icons">
              <Apps24Regular />
              <span>Dashboard</span>
            </div>
          </div>
          <div>
            <h3>Organisation</h3>
            <div className="options--section">
              <div className="left-panel--icons">
                <PersonCircle24Regular />
                <span>Employees</span>
              </div>
              <div className="left-panel--icons">
                <Building24Regular />
                <span>Departments</span>
              </div>
              <div className="left-panel--icons">
                <Briefcase24Regular />
                <span>Projects</span>
              </div>
            </div>
          </div>
          <div>
            <h3>Operations</h3>
            <div className="options--section">
              <div className="left-panel--icons">
                <CalendarCheckmark24Regular />
                <span>Attendance</span>
              </div>
              <div className="left-panel--icons">
                <Clock24Regular />
                <span>Work hours</span>
              </div>
              <div className="left-panel--icons">
                <Beach24Regular />
                <span>Leaves</span>
              </div>
            </div>
          </div>
          <div>
            <h3>Hr</h3>
            <div className="options--section">
              <div className="left-panel--icons">
                <MoneyHand24Regular />
                <span>Payroll</span>
              </div>
              <div className="left-panel--icons">
                <Star24Regular />
                <span>Performance</span>
              </div>
              <div className="left-panel--icons">
                <Laptop24Regular />
                <span>Assests</span>
              </div>
            </div>
          </div>
        </div>

        <div className="left-panel--footer">
          <span className="profile">AD</span>
          <div>
            <div>{empName}</div>
            <div>{role}</div>
          </div>
        </div>
      </div>
      <div className="right-panel">
        <div className="right-panel--header">
          <div>
            <span>Dashboard </span>
            <span>{currDate}</span>
          </div>
          <div className="left-panel--icons">
            <AlertBadge24Regular />
            <span className="profile">AD</span>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Dashboard;
