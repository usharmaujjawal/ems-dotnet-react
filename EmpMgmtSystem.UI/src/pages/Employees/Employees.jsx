import { useState } from "react";
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
      empId: "001",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "002",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "003",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "004",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "005",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "006",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "007",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "008",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "009",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0010",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0011",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0012",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0013",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0014",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0015",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0016",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0017",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0018",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0019",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0020",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
    {
      name: "Riya Shah",
      empId: "0021",
      dept: "Engineering",
      role: "Finance",
      status: "Active",
      hireData: "11/13/2026 17:14:07" /*CultureInvariant datetimeStamp */,
      manager: "Anil Verma",
    },
  ];

  // pagination
  const [currPage, setCurrPage] = useState(1),
    PAGE_SIZE = 10,
    startIndex = (currPage - 1) * PAGE_SIZE,
    endIndex = startIndex + PAGE_SIZE,
    totalPages = Math.ceil(empDetails.length / PAGE_SIZE),
    paginatedEmpData = empDetails.slice(startIndex, endIndex);

  const handlePagination = (value) => {
    setCurrPage(value);
  };

  const handleNext = (item) => {
    if (currPage >= totalPages) return;
    setCurrPage((currPage) => currPage + 1);
  };

  const handlePrevious = (item) => {
    if (currPage <= 1) return;
    setCurrPage((currPage) => currPage - 1);
  };

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
            {paginatedEmpData.map((item, index) => {
              return (
                <tr key={index}>
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
          <div>
            Showing {startIndex + 1}-{Math.min(endIndex, empDetails.length)} of{" "}
            {empDetails.length}{" "}
          </div>
          <div className="pages">
            <div onClick={handlePrevious}>&lt;</div>
            {Array.from({ length: totalPages }, (_, i) => i + 1).map(
              (item, index) => (
                <div
                  onClick={() => {
                    handlePagination(item);
                  }}
                  key={index}
                >
                  {item}
                </div>
              ),
            )}
            <div onClick={handleNext}>&gt;</div>
          </div>
        </div>
      </section>
    </div>
  );
}
