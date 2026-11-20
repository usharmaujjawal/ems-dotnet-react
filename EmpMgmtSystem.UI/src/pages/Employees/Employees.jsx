import { useState, useEffect } from "react";
import "./Employees.css";
import "../../utils/initials";
import {
  ArrowDownloadFilled,
  AddFilled,
  EyeRegular,
  ClipboardEditRegular,
  DeleteRegular,
} from "@fluentui/react-icons";
import getInitials from "../../utils/initials";
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
      role: "Admin",
      status: "Active",
      hireDate: "01/15/2025 09:12:45",
      manager: "Anil Verma",
    },
    {
      name: "Arjun Mehta",
      empId: "002",
      dept: "Finance",
      role: "Manager",
      status: "Active",
      hireDate: "02/10/2025 11:22:18",
      manager: "Priya Nair",
    },
    {
      name: "Sneha Kapoor",
      empId: "003",
      dept: "HR",
      role: "Employee",
      status: "Probation",
      hireDate: "03/05/2025 14:35:09",
      manager: "Vikram Joshi",
    },
    {
      name: "Rahul Sharma",
      empId: "004",
      dept: "Engineering",
      role: "Employee",
      status: "Active",
      hireDate: "04/18/2025 16:45:22",
      manager: "Anil Verma",
    },
    {
      name: "Neha Gupta",
      empId: "005",
      dept: "Finance",
      role: "Admin",
      status: "Inactive",
      hireDate: "05/09/2025 08:17:31",
      manager: "Priya Nair",
    },
    {
      name: "Karan Malhotra",
      empId: "006",
      dept: "HR",
      role: "Manager",
      status: "Active",
      hireDate: "06/02/2025 13:28:54",
      manager: "Vikram Joshi",
    },
    {
      name: "Aditi Singh",
      empId: "007",
      dept: "Engineering",
      role: "Employee",
      status: "Probation",
      hireDate: "07/21/2025 10:14:20",
      manager: "Anil Verma",
    },
    {
      name: "Mohit Arora",
      empId: "008",
      dept: "Finance",
      role: "Employee",
      status: "Active",
      hireDate: "08/14/2025 17:41:15",
      manager: "Priya Nair",
    },
    {
      name: "Pooja Yadav",
      empId: "009",
      dept: "HR",
      role: "Admin",
      status: "Inactive",
      hireDate: "09/11/2025 12:05:44",
      manager: "Vikram Joshi",
    },
    {
      name: "Rohit Jain",
      empId: "010",
      dept: "Engineering",
      role: "Manager",
      status: "Active",
      hireDate: "10/03/2025 09:55:10",
      manager: "Anil Verma",
    },
    {
      name: "Simran Kaur",
      empId: "011",
      dept: "Finance",
      role: "Employee",
      status: "Probation",
      hireDate: "11/19/2025 15:26:08",
      manager: "Priya Nair",
    },
    {
      name: "Aakash Verma",
      empId: "012",
      dept: "HR",
      role: "Manager",
      status: "Active",
      hireDate: "12/07/2025 11:42:28",
      manager: "Vikram Joshi",
    },
    {
      name: "Meera Iyer",
      empId: "013",
      dept: "Engineering",
      role: "Admin",
      status: "Inactive",
      hireDate: "01/08/2026 08:31:19",
      manager: "Anil Verma",
    },
    {
      name: "Yash Patel",
      empId: "014",
      dept: "Finance",
      role: "Employee",
      status: "Active",
      hireDate: "02/17/2026 14:18:42",
      manager: "Priya Nair",
    },
    {
      name: "Nisha Reddy",
      empId: "015",
      dept: "HR",
      role: "Employee",
      status: "Probation",
      hireDate: "03/23/2026 16:07:25",
      manager: "Vikram Joshi",
    },
    {
      name: "Dev Khanna",
      empId: "016",
      dept: "Engineering",
      role: "Manager",
      status: "Active",
      hireDate: "04/29/2026 10:50:39",
      manager: "Anil Verma",
    },
    {
      name: "Ishita Bose",
      empId: "017",
      dept: "Finance",
      role: "Admin",
      status: "Inactive",
      hireDate: "05/13/2026 12:43:16",
      manager: "Priya Nair",
    },
    {
      name: "Saurabh Mishra",
      empId: "018",
      dept: "HR",
      role: "Employee",
      status: "Active",
      hireDate: "06/25/2026 09:24:51",
      manager: "Vikram Joshi",
    },
    {
      name: "Tanvi Chawla",
      empId: "019",
      dept: "Engineering",
      role: "Employee",
      status: "Probation",
      hireDate: "07/07/2026 15:11:33",
      manager: "Anil Verma",
    },
    {
      name: "Abhishek Roy",
      empId: "020",
      dept: "Finance",
      role: "Manager",
      status: "Active",
      hireDate: "08/20/2026 13:37:27",
      manager: "Priya Nair",
    },
    {
      name: "Kavya Menon",
      empId: "021",
      dept: "HR",
      role: "Admin",
      status: "Inactive",
      hireDate: "09/15/2026 11:06:48",
      manager: "Vikram Joshi",
    },
  ];

  // filters - Department, Status, Role and Search
  const [selectedDept, setSelectedDept] = useState(departments[0]);
  const [selectedRole, setSelectedRole] = useState(roles[0]);
  const [selectedStatus, setSelectedStatus] = useState(statuses[0]);
  const [searchTerm, setSearchTerm] = useState(""); // for searching

  const filteredData =
    // adding an extra condition for "All department - in case of All Departments - return all the paginated records."
    empDetails.filter((emp) => {
      const deptMatch =
        selectedDept === departments[0] || emp.dept === selectedDept;

      const roleMatch = selectedRole === roles[0] || emp.role === selectedRole;

      const statusMatch =
        selectedStatus === statuses[0] || emp.status === selectedStatus;

      return deptMatch && roleMatch && statusMatch;
    });

  // Searching
  const searchedData = searchTerm
    ? filteredData.filter(
        (emp) =>
          emp.name.toLowerCase().startsWith(searchTerm.toLowerCase()) ||
          emp.empId
            .toString()
            .toLowerCase()
            .startsWith(searchTerm.toString().toLowerCase()),
      )
    : filteredData;

  // pagination : is based on filtered data
  const [currPage, setCurrPage] = useState(1),
    PAGE_SIZE = 10,
    startIndex = (currPage - 1) * PAGE_SIZE,
    endIndex = startIndex + PAGE_SIZE,
    totalPages = Math.ceil(searchedData.length / PAGE_SIZE),
    visibleStart =
      searchedData.length === 0 ? 0 : (currPage - 1) * PAGE_SIZE + 1,
    visibleEnd = Math.min(currPage * PAGE_SIZE, searchedData.length),
    paginatedEmpData = searchedData.slice(startIndex, endIndex);

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

  // export functionality - select emps records(one or many)
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

  // changing the currPage to 1 whenever there is a change in the filter.- suppose we are on page 2 and then filter records, in this case the paginatedEmpData becomes empty for that page.
  useEffect(() => {
    setCurrPage(1);
  }, [selectedDept, selectedRole, selectedStatus]);

  // similary logic applies to searchedData as well
  useEffect(() => {
    setCurrPage(1);
  }, [searchTerm]);

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
            <input
              type="search"
              placeholder="Search name, email, or code..."
              onChange={(e) => setSearchTerm(e.target.value)}
            />
          </label>
          <label>
            <span className="visually-hidden">Filter by department</span>
            <select
              defaultValue={departments[0]}
              onChange={(e) => setSelectedDept(e.target.value)}
            >
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
            <select
              defaultValue={statuses[0]}
              onChange={(e) => setSelectedStatus(e.target.value)}
            >
              {statuses.map((item, index) => (
                <option value={item} key={index}>
                  {item}
                </option>
              ))}
            </select>
          </label>

          <label>
            <span className="visually-hidden">Filter by role</span>
            <select
              defaultValue={roles[0]}
              onChange={(e) => setSelectedRole(e.target.value)}
            >
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
                  {/* paginationEmpData.length > 0 : added this condition because of vacuous truth. i.e [].every(() => false) return true and even for an empty paginatedEmpData the below every condition will return true since there are no numbers that violate the condition as a consequence even though we do not have any paginated data the checkbox on top header will be shown checked. */}
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
                          {getInitials(item.name)}
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
                    <td>{item.hireDate}</td>
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
              Showing {visibleStart}-{visibleEnd} of {searchedData.length}{" "}
              employees
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
