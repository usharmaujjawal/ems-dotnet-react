import "./Dashboard.css";
import ProgressBar from "../../components/ProgressBar/ProgressBar";
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

  const headCount = [
    { label: "Engineering", count: 80, color: "red" },
    { label: "Sales", count: 10, color: "pink" },
    { label: "HR", count: 50, color: "orange" },
    { label: "Finance", count: 40, color: "blue" },
    { label: "Design", count: 30, color: "orangered" },
    { label: "Operations", count: 70, color: "brown" },
  ];

  const days = ["M", "T", "W", "T", "F", "S", "S"];

  const attendanceRows = [
    ["P", "P", "P", "P", "P", "H", "H"],
    ["P", "P", "P", "A", "P", "H", "H"],
    ["P", "P", "P", "P", "P", "H", "H"],
  ];

  const leaveRequests = [
    {
      initials: "RS",
      name: "Riya Shah",
      type: "Sick leave",
      startDate: "2026-06-17",
      endDate: "2026-06-18",
      status: "Pending",
    },
    {
      initials: "MK",
      name: "Mohit Kumar",
      type: "Casual",
      startDate: "2026-06-20",
      endDate: null,
      status: "Pending",
    },
    {
      initials: "AS",
      name: "Asha Sinha",
      type: "Annual",
      startDate: "2026-07-01",
      endDate: "2026-07-05",
      status: "Approved",
    },
    {
      initials: "VP",
      name: "Vivek Patel",
      type: "Sick leave",
      startDate: "2026-06-16",
      endDate: null,
      status: "Approved",
    },
  ];

  const formatLeavePeriod = (startDate, endDate) => {
    const options = { month: "short", day: "numeric" }; // Format the date as short month + numeric day

    const startDateStr = new Date(startDate).toLocaleDateString(
      "en-US",
      options,
    );

    if (!endDate) return startDateStr;

    const endDateStr = new Date(endDate).toLocaleDateString("en-US", options);

    return `${startDateStr} - ${endDateStr}`;
  };

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
        <div className="right-panel--main">
          <div className="main--firstRow">
            <div>
              <div className="left-panel--icons">
                <PersonCircle24Regular />
                <div>Total Employees</div>
              </div>
              <div>248</div>
              <div>+6 this month</div>
            </div>
            <div>
              <div className="left-panel--icons">
                <CalendarCheckmark24Regular />
                <div>Present today</div>
              </div>
              <div>211</div>
              <div>85.1% attendance rate</div>
            </div>
            <div>
              <div className="left-panel--icons">
                <Beach24Regular />
                <div>On leave</div>
              </div>
              <div>14</div>
              <div>4 pending approval</div>
            </div>
            <div>
              <div className="left-panel--icons">
                <MoneyHand24Regular />
                <div>Payroll(Jun)</div>
              </div>
              <div>$18.4L</div>
              <div>Processed</div>
            </div>
          </div>
          <div className="main--secondRow">
            <div className="secondRow--headCount">
              <div className="secondRow--header">
                <div>Headcount by department</div>
                <div>View all</div>
              </div>
              {headCount.map((item, index) => (
                <div className="secondRow--items" key={index}>
                  <div>{item.label}</div>
                  <ProgressBar color={item.color} percentage={item.count} />
                  <div>{item.count}</div>
                </div>
              ))}
            </div>
            <div>
              <div className="secondRow--header">
                <div>Leave requests</div>
                <div>Review all</div>
              </div>
              {leaveRequests.map((item, index) => (
                <div key={index} className="secondRow--leaveItem">
                  <div className="profile">RS</div>
                  <div>
                    <div>{item.name}</div>
                    <div>{item.type}</div>
                    <div>{formatLeavePeriod(item.startDate, item.endDate)}</div>
                  </div>
                  <div className="leaveStatus">{item.status}</div>
                </div>
              ))}
            </div>
          </div>
          <div className="main--thirdRow">
            <div className="thirdRow--header">
              <div>My attendance -- June 2026</div>
              <div>Full log</div>
            </div>
            <table>
              <thead>
                <tr>
                  {days.map((item, index) => (
                    <th key={index}>{item}</th>
                  ))}
                </tr>
              </thead>
              <tbody>
                {attendanceRows.map((item, index) => (
                  <tr key={index}>
                    {item.map((item, index) => (
                      <th key={index}>{item}</th>
                    ))}
                  </tr>
                ))}
              </tbody>
            </table>
            <div className="thirdRow--footer">
              <div className="footer-item">
                <div>P</div>
                <div>Present(13)</div>
              </div>
              <div className="footer-item">
                <div>A</div>
                <div>Absent(1)</div>
              </div>
              <div className="footer-item">
                <div>H</div>
                <div>Holiday(7)</div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Dashboard;
