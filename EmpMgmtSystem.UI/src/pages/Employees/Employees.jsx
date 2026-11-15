import "./Employees.css";
import {
  ArrowDownloadFilled,
  AddFilled,
  EyeRegular,
  ClipboardEditRegular,
  DeleteRegular,
} from "@fluentui/react-icons";
export default function Employees() {
  //dynamic data - will be replaced with the actual api call once the backend is available.
  const roles = ["All roles", "Admin", "Manager", "Employee"];
  const departments = ["All departments", "Engineering", "HR", "Finance"];
  const statues = ["All statues", "Active", "Inactive", "Probation"];

  const empDetailsHeader = [
    "Employee",
    "Department",
    "Role",
    "Status",
    "Hire date",
    "Manager",
    "",
  ];
  const empDetails = [
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0024",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
  ];

  return (
    <div className="emp-container">
      <header className="emp-header">
        <div className="emp-total">
          <span>Employees</span>
          <span>{empDetails.length} total</span>
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
            {departments.map((item, index) => {
              return (
                <option value={item} key={index}>
                  {item}
                </option>
              );
            })}
          </select>

          <select>
            {statues.map((item, index) => (
              <option value={item} key={index}>
                {item}
              </option>
            ))}
          </select>

          <select>
            {roles.map((item, index) => (
              <option value={item} key={index}>
                {item}
              </option>
            ))}
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
              {empDetailsHeader.map((item, index) => (
                <th key={index}>{item}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            {empDetails.map((item, index) => {
              return (
                <tr>
                  <td>
                    <input type="checkbox"></input>
                  </td>
                  <td className="profile-initials">
                    <div>RS</div>
                    <div>{item.name}</div>
                    <div>Emp-{item.empId}</div>
                  </td>
                  <td>{item.dept}</td>
                  <td>{item.role}</td>
                  <td>{item.status}</td>
                  <td>{item.hireData}</td>
                  <td>{item.manager}</td>
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
              );
            })}
          </tbody>
        </table>

        <div className="details--page">
          <div>Showing 1-10 of {empDetails.length} </div>
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
