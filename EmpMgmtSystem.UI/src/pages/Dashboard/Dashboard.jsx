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
    <main className="dashboard-page-container">
      <aside className="left-panel">
        <header className="left-panel--header">
          <span className="icon-filled"></span>
          <span>EmpManage</span>
        </header>

        <nav className="left-panel--options">
          <ul className="options--section">
            <li className="left-panel--icons">
              <Apps24Regular />
              <span>Dashboard</span>
            </li>
          </ul>
          <section>
            <h3>Organization</h3>
            <ul className="options--section">
              <li className="left-panel--icons">
                <PersonCircle24Regular />
                <span>Employees</span>
              </li>
              <li className="left-panel--icons">
                <Building24Regular />
                <span>Departments</span>
              </li>
              <li className="left-panel--icons">
                <Briefcase24Regular />
                <span>Projects</span>
              </li>
            </ul>
          </section>
          <section>
            <h3>Operations</h3>
            <ul className="options--section">
              <li className="left-panel--icons">
                <CalendarCheckmark24Regular />
                <span>Attendance</span>
              </li>
              <li className="left-panel--icons">
                <Clock24Regular />
                <span>Work hours</span>
              </li>
              <li className="left-panel--icons">
                <Beach24Regular />
                <span>Leaves</span>
              </li>
            </ul>
          </section>
          <section>
            <h3>Hr</h3>
            <ul className="options--section">
              <li className="left-panel--icons">
                <MoneyHand24Regular />
                <span>Payroll</span>
              </li>
              <li className="left-panel--icons">
                <Star24Regular />
                <span>Performance</span>
              </li>
              <li className="left-panel--icons">
                <Laptop24Regular />
                <span>Assests</span>
              </li>
            </ul>
          </section>
        </nav>

        <footer className="left-panel--footer">
          <span className="profile">AD</span>
          <div>
            <div>{empName}</div>
            <div>{role}</div>
          </div>
        </footer>
      </aside>
      <section className="right-panel">
        <header className="right-panel--header">
          <div>
            <span>Dashboard </span>
            <span>{currDate}</span>
          </div>
          <div className="left-panel--icons">
            <AlertBadge24Regular />
            <span className="profile">AD</span>
          </div>
        </header>
        <main className="right-panel--main">
          <section className="main--firstRow">
            <article>
              <div className="left-panel--icons">
                <PersonCircle24Regular />
                <div>Total Employees</div>
              </div>
              <div>248</div>
              <div>+6 this month</div>
            </article>
            <article>
              <div className="left-panel--icons">
                <CalendarCheckmark24Regular />
                <div>Present today</div>
              </div>
              <div>211</div>
              <div>85.1% attendance rate</div>
            </article>
            <article>
              <div className="left-panel--icons">
                <Beach24Regular />
                <div>On leave</div>
              </div>
              <div>14</div>
              <div>4 pending approval</div>
            </article>
            <article>
              <div className="left-panel--icons">
                <MoneyHand24Regular />
                <div>Payroll(Jun)</div>
              </div>
              <div>$18.4L</div>
              <div>Processed</div>
            </article>
          </section>
          <div className="main--secondRow">
            <section className="secondRow--headCount">
              <header className="secondRow--header">
                <div>Headcount by department</div>
                <div>View all</div>
              </header>
              {headCount.map((item, index) => (
                <div className="secondRow--items" key={index}>
                  <div>{item.label}</div>
                  <ProgressBar color={item.color} percentage={item.count} />
                  <div>{item.count}</div>
                </div>
              ))}
            </section>
            <section>
              <header className="secondRow--header">
                <div>Leave requests</div>
                <div>Review all</div>
              </header>
              {leaveRequests.map((item, index) => (
                <article key={index} className="secondRow--leaveItem">
                  <div className="profile">RS</div>
                  <div>
                    <h4>{item.name}</h4>
                    <p>{item.type}</p>
                    <time>
                      {formatLeavePeriod(item.startDate, item.endDate)}
                    </time>
                  </div>
                  <div className="leaveStatus">{item.status}</div>
                </article>
              ))}
            </section>
          </div>
          <div className="main--thirdRow">
            <header className="thirdRow--header">
              <div>My attendance -- June 2026</div>
              <div>Full log</div>
            </header>
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
            <footer className="thirdRow--footer">
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
            </footer>
          </div>
        </main>
      </section>
    </main>
  );
}

export default Dashboard;
