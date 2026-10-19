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
            <div>
              <div className="secondRow--header">
                <div>Headcount by department</div>
                <div>View all</div>
              </div>
              <div className="secondRow--items">
                <div>Engineering</div>
                <div>ProgressBar</div>
                <div>88</div>
              </div>
              <div className="secondRow--items">
                <div>Sales</div>
                <div>ProgressBar</div>
                <div>52</div>
              </div>
              <div className="secondRow--items">
                <div>HR</div>
                <div>ProgressBar</div>
                <div>30</div>
              </div>
              <div className="secondRow--items">
                <div>Finance</div>
                <div>ProgressBar</div>
                <div>26</div>
              </div>
              <div className="secondRow--items">
                <div>Design</div>
                <div>ProgressBar</div>
                <div>18</div>
              </div>
              <div className="secondRow--items">
                <div>Operations</div>
                <div>ProgressBar</div>
                <div>34</div>
              </div>
            </div>
            <div>
              <div className="secondRow--header">
                <div>Leave requests</div>
                <div>Review all</div>
              </div>
              <div className="secondRow--leaveItem">
                <div className="profile">RS</div>
                <div>
                  <div>Riya Shah</div>
                  <div>Sick leave</div>
                  <div>Jun 17-18</div>
                </div>
                <div className="leaveStatus">Pending</div>
              </div>
              <div className="secondRow--leaveItem">
                <div className="profile">MK</div>
                <div>
                  <div>Mohit Kumar</div>
                  <div>Casual</div>
                  <div>Jun 20</div>
                </div>
                <div className="leaveStatus">Pending</div>
              </div>
              <div className="secondRow--leaveItem">
                <div className="profile">AS</div>
                <div>
                  <div>Asha Sinha</div>
                  <div>Annual</div>
                  <div>Jul 1-5</div>
                </div>
                <div className="leaveStatus">Pending</div>
              </div>
              <div className="secondRow--leaveItem">
                <div className="profile">VP</div>
                <div>
                  <div>Vivek Patel</div>
                  <div>Sick leave</div>
                  <div>Jun 16</div>
                </div>
                <div className="leaveStatus">Pending</div>
              </div>
            </div>
          </div>
          <div className="main--thirdRow">
            <div className="secondRow--header">
              <div>My attendance -- June 2026</div>
              <div>Full log</div>
            </div>
            <table>
              <thead>
                <tr>
                  <th>M</th>
                  <th>T</th>
                  <th>W</th>
                  <th>T</th>
                  <th>F</th>
                  <th>S</th>
                  <th>S</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>P</td>
                  <td>P</td>
                  <td>P</td>
                  <td>P</td>
                  <td>P</td>
                  <td>H</td>
                  <td>H</td>
                </tr>
                <tr>
                  <td>P</td>
                  <td>P</td>
                  <td>P</td>
                  <td>A</td>
                  <td>P</td>
                  <td>H</td>
                  <td>H</td>
                </tr>
                <tr>
                  <td>P</td>
                  <td>P</td>
                  <td>P</td>
                  <td>P</td>
                  <td>P</td>
                  <td>H</td>
                  <td>H</td>
                </tr>
              </tbody>
            </table>
            <div className="secondRow--footer">
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
