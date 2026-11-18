import { useState, useEffect } from "react";
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
  const statuses = ["All statuses", "Active", "Inactive", "Probation"];

  const empDetailsHeader = [
    "Employee",
    "Department",
    "Role",
    "Status",
    "Hire date",
    "Manager",
    "Actions",
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

  const handleNext = () => {
    if (currPage >= totalPages) return;
    setCurrPage((currPage) => currPage + 1);
  };

  const handlePrevious = () => {
    if (currPage <= 1) return;
    setCurrPage((currPage) => currPage - 1);
  };

  // export functionality
  const [selectedEmployees, setSelectedEmployees] = useState([]);

  // if the selected empids are present in the list remove them - works in case of Deselection and if they are not present add them - works in case of Selection.
  const handleEmpSelect = (empId) => {
    setSelectedEmployees((prev) =>
      prev.includes(empId)
        ? prev.filter((id) => id !== empId)
        : [...prev, empId],
    );
  };

  const handleAllSelected = () => {
    const currentPageEmpIds = paginatedEmpData.map((emp) => emp.empId);

    // checks whether all the empIds of the currentPage are selected or not
    const allSelected = currentPageEmpIds.every((id) =>
      selectedEmployees.includes(id),
    );

    // if all the ids are selected - then remove all the currentPageIds keeping the rest of the empIds(selected from other pages right): this is the case for uncheck
    if (allSelected) {
      setSelectedEmployees((prev) =>
        prev.filter((id) => !currentPageEmpIds.includes(id)),
      );
    }

    // else - add all the currentPageIds, along with prev selected ids by removing duplicated ids(may be some are selected and some are not page so using Set to remove the duplicate empIds from the array.)
    else {
      setSelectedEmployees((prev) => [
        ...new Set([...prev, ...currentPageEmpIds]),
      ]);
    }
  };

  return (
    <div className="employees-page">
      <header className="employees-header">
        <div className="employees-heading">
          <p className="employees-eyebrow">Organization</p>
          <h1>Employees</h1>
          <p className="employees-summary">
            <span>{empDetails.length} employees</span>
            <span className="employees-summary-divider" aria-hidden="true">
              ·
            </span>
            <span>6 added this month</span>
          </p>
        </div>
        <div className="employees-actions">
          <button
            className="employees-button employees-button--secondary"
            type="button"
          >
            <span className="employees-button-icon">
              <ArrowDownloadFilled />
            </span>
            Export
          </button>
          <button
            className="employees-button employees-button--primary"
            type="button"
          >
            <span className="employees-button-icon">
              <AddFilled />
            </span>
            Add employee
          </button>
        </div>
      </header>

      <main className="employees-content">
        <section className="employees-toolbar" aria-label="Employee filters">
          <label className="employees-search">
            <span className="visually-hidden">Search employees</span>
            <input type="search" placeholder="Search name, email, or code..." />
          </label>
          <label>
            <span className="visually-hidden">Filter by department</span>
            <select defaultValue={departments[0]}>
              {departments.map((item, index) => {
                return (
                  <option value={item} key={index}>
                    {item}
                  </option>
                );
              })}
            </select>
          </label>

          <label>
            <span className="visually-hidden">Filter by status</span>
            <select defaultValue={statuses[0]}>
              {statuses.map((item, index) => (
                <option value={item} key={index}>
                  {item}
                </option>
              ))}
            </select>
          </label>

          <label>
            <span className="visually-hidden">Filter by role</span>
            <select defaultValue={roles[0]}>
              {roles.map((item, index) => (
                <option value={item} key={index}>
                  {item}
                </option>
              ))}
            </select>
          </label>
        </section>

        <section className="employees-card" aria-label="Employee directory">
          <div className="employees-table-scroll">
            <table className="employees-table">
              <thead>
                <tr>
                  {/* paginationEmpData.length > 0 : added this condition because of vacuous truth. i.e [].every(() => false) return true and even for an empty paginatedEmpData the below every condition will return true since there are no numbers that violate the condition*/}
                  <th scope="col">
                    <input
                      type="checkbox"
                      aria-label="Select all employees"
                      onChange={handleAllSelected}
                      checked={
                        paginatedEmpData.length > 0 &&
                        paginatedEmpData.every((emp) =>
                          selectedEmployees.includes(emp.empId),
                        )
                      }
                    />
                  </th>
                  {empDetailsHeader.map((item, index) => (
                    <th key={index} scope="col">
                      {item}
                    </th>
                  ))}
                </tr>
              </thead>
              <tbody>
                {paginatedEmpData.map((item) => (
                  <tr key={item.empId}>
                    <td>
                      <input
                        type="checkbox"
                        aria-label={`Select ${item.name}`}
                        onChange={() => handleEmpSelect(item.empId)}
                        checked={selectedEmployees.includes(item.empId)}
                      />
                    </td>
                    <td>
                      <div className="employee-identity">
                        <span className="employee-avatar" aria-hidden="true">
                          RS
                        </span>
                        <span className="employee-identity-details">
                          <span className="employee-name">{item.name}</span>
                          <span className="employee-id">Emp-{item.empId}</span>
                        </span>
                      </div>
                    </td>
                    <td>{item.dept}</td>
                    <td>{item.role}</td>
                    <td>
                      <span className="employee-status">{item.status}</span>
                    </td>
                    <td>{item.hireData}</td>
                    <td>{item.manager}</td>
                    <td>
                      <div className="employee-row-actions">
                        <button
                          type="button"
                          aria-label={`View ${item.name}`}
                          title="View employee"
                        >
                          <EyeRegular />
                        </button>
                        <button
                          type="button"
                          aria-label={`Edit ${item.name}`}
                          title="Edit employee"
                        >
                          <ClipboardEditRegular />
                        </button>
                        <button
                          type="button"
                          aria-label={`Delete ${item.name}`}
                          title="Delete employee"
                        >
                          <DeleteRegular />
                        </button>
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

          <footer className="employees-pagination">
            <span className="employees-pagination-summary">
              Showing {startIndex + 1}-{Math.min(endIndex, empDetails.length)}{" "}
              of {empDetails.length} employees
            </span>
            <nav className="employees-pages" aria-label="Employee pages">
              <button
                type="button"
                onClick={handlePrevious}
                disabled={currPage <= 1}
                aria-label="Previous page"
              >
                &lt;
              </button>
              {Array.from({ length: totalPages }, (_, i) => i + 1).map(
                (item) => (
                  <button
                    type="button"
                    onClick={() => handlePagination(item)}
                    key={item}
                    aria-current={currPage === item ? "page" : undefined}
                  >
                    {item}
                  </button>
                ),
              )}
              <button
                type="button"
                onClick={handleNext}
                disabled={currPage >= totalPages}
                aria-label="Next page"
              >
                &gt;
              </button>
            </nav>
          </footer>
        </section>
      </main>
    </div>
  );
}
