import "./Employees.css";
import {
  ArrowDownloadFilled,
  AddFilled,
  EyeRegular,
  ClipboardEditRegular,
  DeleteRegular,
} from "@fluentui/react-icons";
export default function Employees() {
  return (
    <div className="emp-container">
      <header className="emp-header">
        <div className="emp-total">
          <span>Employees</span>
          <span>248 total</span>
          <span>.6 added this month</span>
        </div>
        <div className="emp-export">
          <div className="export--item">
            <div>
              <ArrowDownloadFilled />
            </div>
            <div>Export</div>
          </div>
          <div className="export--item">
            <div>
              <AddFilled />
            </div>
            <div>Add employee</div>
          </div>
        </div>
      </header>

      <main>
        <div className="emp-main">
          <input type="search" placeholder="Search name, email, code..." />
          <select>
            <option value="all">All Department</option>
            <option value="engineering">Engineering</option>
            <option value="hr">HR</option>
            <option value="hr">Finance</option>
          </select>

          <select>
            <option value="all">All Status</option>
            <option value="active">Active</option>
            <option value="inactive">Inactive</option>
            <option value="probation">Probation</option>
          </select>

          <select>
            <option value="all">All Roles</option>
            <option value="admin">Admin</option>
            <option value="manager">Manager</option>
            <option value="employee">Employee</option>
          </select>
        </div>
      </main>

      <section className="emp-details">
        <table>
          <thead>
            <tr>
              <th>
                <input type="checkbox" />
              </th>
              <th>Employee</th>
              <th>Department</th>
              <th>Role</th>
              <th>Status</th>
              <th>Hire date</th>
              <th>Manager</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>
                <input type="checkbox"></input>
              </td>
              <td className="profile-initials">
                <div>RS</div>
                <div>Riya Shah</div>
                <div>Emp-0024</div>
              </td>
              <td>Engineering</td>
              <td>Finance</td>
              <td>Active</td>
              <td>12 Mar 2022</td>
              <td>Anil Verma</td>
              <td className="emp-actions">
                <div>
                  <EyeRegular />
                </div>
                <div>
                  <ClipboardEditRegular />
                </div>
                <div>
                  <DeleteRegular />
                </div>
              </td>
            </tr>
            <tr>
              <td>
                <input type="checkbox"></input>
              </td>
              <td className="profile-initials">
                <div>RS</div>
                <div>Riya Shah</div>
                <div>Emp-0024</div>
              </td>
              <td>Engineering</td>
              <td>Finance</td>
              <td>Active</td>
              <td>12 Mar 2022</td>
              <td>Anil Verma</td>
              <td className="emp-actions">
                <div>
                  <EyeRegular />
                </div>
                <div>
                  <ClipboardEditRegular />
                </div>
                <div>
                  <DeleteRegular />
                </div>
              </td>
            </tr>
          </tbody>
        </table>

        <div className="details--page">
          <div>Showing 1-5 of 248 </div>
          <div className="pages">
            <div>&lt;</div>
            <div>1</div>
            <div>2</div>
            <div>3</div>
            <div>4</div>
            <div>...</div>
            <div>50</div>

            <div>&gt;</div>
          </div>
        </div>
      </section>
    </div>
  );
}
