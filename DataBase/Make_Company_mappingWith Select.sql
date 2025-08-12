
CREATE Table Employee(
  EmpID int  PRIMARY KEY,
  fName NVARCHAR(50) NOT NULL,
  Minit NVARCHAR(50) NOT NULL,
  lName NVARCHAR(50) NOT NULL,
  Address NVARCHAR(100) NOT NULL,
  Salary DECIMAL(10, 2) NOT NULL,
  Gender NVARCHAR(10) NOT NULL,
  BirthDate DATE NOT NULL,
)
  
  -- SuperVisorID int NULL,
  --     DeptName NVARCHAR(50) NULL,
  -- FOREIGN KEY (Dependentname) REFERENCES Department(DeptName),
  -- FOREIGN KEY (SuperVisorID) REFERENCES Employee(EmpID)



CREATE TABLE Dependents(
 Dependentname NVARCHAR(50) PRIMARY KEY,
    gender NVARCHAR(10) NOT NULL,
  BirthDate DATE NOT NULL,
  Relationship NVARCHAR(50) NOT NULL,
  EmpID int NOT NULL,
  
)
  -- FOREIGN KEY (EmpID) REFERENCES Employee(EmpID)



CREATE TABLE Department(
  DeptName NVARCHAR(50) NOT NULL PRIMARY KEY,
  Number int NOT NULL,
  LocationID int NOT NULL,
  managerID int NOT NULL,
)
  -- FOREIGN KEY (magerID) REFERENCES Employee(EmpID),
  -- FOREIGN KEY (LocationID) REFERENCES Location(LocationID)

create Table Location(
  LocationID int PRIMARY KEY,
  LocationName NVARCHAR(50) NOT NULL,
)



CREATE Table Project(
  
  ProjectName NVARCHAR(50) NOT NULL,
  ProjectNumber int not NULL,
  DeptName NVARCHAR(50) NOT NULL,
  PRIMARY KEY (ProjectName, ProjectNumber),
);
  -- FOREIGN KEY (DeptName) REFERENCES Department(DeptName),




CREATE Table Project_Employee(
  ProjectName NVARCHAR(50) NOT NULL,
  ProjectNumber int NOT NULL,
  EmpID int NOT NULL,
  Hours int NOT NULL,
  
  FOREIGN KEY (ProjectName, ProjectNumber) REFERENCES Project(ProjectName, ProjectNumber),
  FOREIGN KEY (EmpID) REFERENCES Employee(EmpID),
  
  PRIMARY KEY (ProjectName, ProjectNumber, EmpID)
);




--- Adding foreign key constraints to the existing tables




ALTER TABLE Employee
ADD 
    SuperVisorID INT NULL,
    DeptName NVARCHAR(50) NULL;


ALTER TABLE Employee
ADD 
    CONSTRAINT FK_Employee_SuperVisor 
        FOREIGN KEY (SuperVisorID) REFERENCES Employee(EmpID),
        
    CONSTRAINT FK_Employee_Department 
        FOREIGN KEY (DeptName) REFERENCES Department(DeptName);




-- Dependents relation
ALTER TABLE Dependents
ADD CONSTRAINT FK_Dependents_Employee FOREIGN KEY (EmpID) REFERENCES Employee(EmpID);

-- Department manager
ALTER TABLE Department
ADD CONSTRAINT FK_Department_Manager FOREIGN KEY (managerID) REFERENCES Employee(EmpID);

-- Department location
ALTER TABLE Department
ADD CONSTRAINT FK_Department_Location FOREIGN KEY (LocationID) REFERENCES Location(LocationID);

-- Project department
ALTER TABLE Project
ADD CONSTRAINT FK_Project_Department FOREIGN KEY (DeptName) REFERENCES Department(DeptName);





-- insert data into the tables 



INSERT INTO Location VALUES (1, N'Cairo');
INSERT INTO Location VALUES (2, N'Giza');
INSERT INTO Location VALUES (3, N'Alexandria');
INSERT INTO Location VALUES (4, N'Mansoura');
INSERT INTO Location VALUES (5, N'Tanta');




INSERT INTO Employee (EmpID, fName, Minit, lName, Address, Salary, Gender, BirthDate)
VALUES 
(1, N'Hassan', N'A', N'Salem', N'Street 1', 8479.00, N'Male', '1984-09-24'),
(2, N'Khaled', N'A', N'Mahmoud', N'Street 2', 8014.00, N'Male', '1975-10-24'),
(3, N'Mohamed', N'M', N'Fathy', N'Street 3', 8200.00, N'Male', '1980-06-15'),
(4, N'Samira', N'I', N'Hassan', N'Street 4', 7600.00, N'Female', '1986-03-10'),
(5, N'Nourhan', N'A', N'Sobhy', N'Street 5', 9100.00, N'Female', '1992-01-11'),
(6, N'Ibrahim', N'Y', N'Younis', N'Street 6', 7890.00, N'Male', '1989-08-09'),
(7, N'Fatma', N'Z', N'Ahmed', N'Street 7', 9500.00, N'Female', '1990-02-19'),
(8, N'Ali', N'K', N'Gaber', N'Street 8', 9700.00, N'Male', '1982-11-12'),
(9, N'Sara', N'B', N'Kamal', N'Street 9', 8800.00, N'Female', '1988-07-07'),
(10, N'Tarek', N'L', N'Essam', N'Street 10', 9200.00, N'Male', '1981-12-21');






INSERT INTO Department (DeptName, Number, LocationID, managerID)
VALUES 
(N'HR', 1, 5, 8),
(N'IT', 2, 4, 6),
(N'Finance', 3, 3, 7),
(N'Marketing', 4, 2, 5),
(N'Sales', 5, 1, 3);



-- مثال: تحديث جدول Employee لإضافة DeptName لكل موظف حسب رقم الموظف (EmpID)

UPDATE Employee SET DeptName = N'HR' WHERE EmpID = 1;
UPDATE Employee SET DeptName = N'IT' WHERE EmpID = 2;
UPDATE Employee SET DeptName = N'Finance' WHERE EmpID = 3;
UPDATE Employee SET DeptName = N'Marketing' WHERE EmpID = 4;
UPDATE Employee SET DeptName = N'Sales' WHERE EmpID = 5;
UPDATE Employee SET DeptName = N'HR' WHERE EmpID = 6;
UPDATE Employee SET DeptName = N'IT' WHERE EmpID = 7;
UPDATE Employee SET DeptName = N'Finance' WHERE EmpID = 8;
UPDATE Employee SET DeptName = N'Marketing' WHERE EmpID = 9;
UPDATE Employee SET DeptName = N'Sales' WHERE EmpID = 10;





SELECT * FROM Employee WHERE DeptName IS NULL;



ALTER TABLE Employee
ALTER COLUMN DeptName NVARCHAR(50) NOT NULL;






INSERT INTO Project (ProjectName, ProjectNumber, DeptName)
VALUES 
(N'AI Recruitment System', 1001, N'HR'),
(N'Network Upgrade', 1002, N'IT'),
(N'Budget Tracker', 1003, N'Finance'),
(N'Social Media Campaign', 1004, N'Marketing'),
(N'E-Commerce Platform', 1005, N'Sales');






INSERT INTO Project_Employee (ProjectName, ProjectNumber, EmpID, Hours)
VALUES 
(N'AI Recruitment System', 1001, 1, 10),
(N'AI Recruitment System', 1001, 2, 8),
(N'Network Upgrade', 1002, 3, 12),
(N'Network Upgrade', 1002, 4, 6),
(N'Budget Tracker', 1003, 5, 9),
(N'Social Media Campaign', 1004, 6, 7),
(N'Social Media Campaign', 1004, 7, 11),
(N'E-Commerce Platform', 1005, 8, 10),
(N'E-Commerce Platform', 1005, 9, 8),
(N'Budget Tracker', 1003, 10, 6);


SELECT DISTINCT top 5 
    E.EmpID, E.fName, E.lName, E.Salary, D.DeptName
FROM
    CompanyDB.dbo.Employee E
INNER JOIN
    CompanyDB.dbo.Department D ON E.DeptName = D.DeptName
WHERE 
    E.Salary > 8500
ORDER BY
    E.lName DESC;




SELECT DISTINCT 
    ProjectName, ProjectNumber, DeptName
FROM 
    CompanyDB.dbo.Project
WHERE 
    DeptName <> 'Finance' AND ProjectNumber < 1005
ORDER BY 
    ProjectNumber DESC;





SELECT DISTINCT TOP 3 
     PE.EmpID, E.fName, PE.ProjectName, PE.Hours
FROM 
    CompanyDB.dbo.Project_Employee PE
JOIN 
    CompanyDB.dbo.Employee E ON PE.EmpID = E.EmpID
WHERE 
    PE.Hours > 8
ORDER BY 
    PE.Hours DESC;





SELECT DISTINCT TOP 3 
     PE.EmpID, E.fName, PE.ProjectName, PE.Hours
FROM 
    CompanyDB.dbo.Project_Employee PE
JOIN 
    CompanyDB.dbo.Employee E ON PE.EmpID = E.EmpID
WHERE 
    PE.Hours > 8
ORDER BY 
    PE.Hours DESC;






SELECT DISTINCT 
    D.Dependentname, D.BirthDate, E.fName
FROM 
    CompanyDB.dbo.Dependents D
JOIN 
    CompanyDB.dbo.Employee E ON D.EmpID = E.EmpID
WHERE 
    D.BirthDate < '2012-01-01' AND E.fName LIKE 'A%'
ORDER BY 
    D.BirthDate DESC;



