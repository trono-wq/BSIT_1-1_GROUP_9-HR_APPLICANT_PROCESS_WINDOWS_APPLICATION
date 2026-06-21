CREATE DATABASE hr_applicant_process_window_application;
USE hr_applicant_process_window_application;

CREATE TABLE Roles 
(
    role_id INT AUTO_INCREMENT PRIMARY KEY,
    role_name VARCHAR(100) NOT NULL
);

INSERT INTO Roles (role_name)
VALUES
('HR Manager / Admin'),
('HR Staff');

CREATE TABLE Users 
(
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    role_id INT,
    email VARCHAR(255) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    o_user_created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    o_last_user_login_at DATETIME,

    FOREIGN KEY (role_id) 
        REFERENCES Roles(role_id)
);

INSERT INTO Users
(role_id, email, password)
VALUES
(1, 'hrma@gmail.com', 'password123'), 
(2, 'hrs@gmail.com', 'password456');

CREATE TABLE ApplicantAccounts 
(
    applicant_account_id INT AUTO_INCREMENT PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    account_status ENUM('Active','Inactive'),
    o_account_created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    o_last_account_login_at DATETIME,
    o_last_account_password_update DATETIME
);

CREATE TABLE Applicants 
(
    applicant_id INT AUTO_INCREMENT PRIMARY KEY,
    applicant_account_id INT UNIQUE,
    pi_full_name VARCHAR(100),
    pi_date_of_birth DATE,
    pi_gender ENUM('Male','Female','Prefer not say'),
    pi_civil_status ENUM('Single','Married'),
    pi_nationality VARCHAR(100),
    address TEXT,
    contact VARCHAR(100),
    education TEXT,
    skills TEXT,
    work_experience TEXT,
    o_profile_created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    o_last_profile_update_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,

    FOREIGN KEY (applicant_account_id)
        REFERENCES ApplicantAccounts(applicant_account_id)
);

CREATE TABLE Departments 
(
    department_id INT AUTO_INCREMENT PRIMARY KEY,
    department_name VARCHAR(100),
    o_department_updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,
    o_department_updated_by INT,

    FOREIGN KEY (o_department_updated_by)
        REFERENCES Users(user_id)
);

INSERT INTO Departments
(department_name)
VALUES
('IT'), ('Finance'), ('Marketing');

CREATE TABLE PositionTypes
(
    position_type_id INT AUTO_INCREMENT PRIMARY KEY,
	position_type_name VARCHAR(100),
    o_position_type_updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    o_position_type_added_by INT,

    FOREIGN KEY (o_position_type_added_by)
        REFERENCES Users(user_id)
);

INSERT INTO PositionTypes
(position_type_name)
VALUES
('Manager'), ('Assistant'), ('Coordinator');

CREATE TABLE EmploymentTypes 
(
    employment_type_id INT AUTO_INCREMENT PRIMARY KEY,
    employment_type_name VARCHAR(100),
    o_employment_type_added_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    o_employment_type_added_by INT,

    FOREIGN KEY (o_employment_type_added_by)
        REFERENCES Users(user_id)
);

INSERT INTO EmploymentTypes
(employment_type_name)
VALUES
('Full-Time'), ('Part-Time'), ('Contractual');

CREATE TABLE JobVacancies 
(
    job_vacancy_id INT AUTO_INCREMENT PRIMARY KEY,
    employment_type_id INT,
    department_id INT,
    position_type_id INT,
    qualifications TEXT,
    required_documents TEXT,
    vacancy_status ENUM('Open','Closed'),
    o_vacancy_updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,
    o_vacancy_updated_by INT,

    FOREIGN KEY (employment_type_id) 
        REFERENCES EmploymentTypes(employment_type_id),
    FOREIGN KEY (department_id)
        REFERENCES Departments(department_id),
	FOREIGN KEY (position_type_id)
		REFERENCES PositionTypes(position_type_id),
    FOREIGN KEY (o_vacancy_updated_by) 
        REFERENCES Users(user_id)
);

CREATE TABLE Applications 
(
    application_id INT AUTO_INCREMENT PRIMARY KEY,
    applicant_id INT,
    job_vacancy_id INT,
    UNIQUE (applicant_id, job_vacancy_id),
    application_status ENUM(
        'Draft', 
        'Submitted',
        'Under Review', 
        'Shortlisted',
        'For Interview', 
        'For Assessment',
        'For Final Review', 
        'Accepted',
        'Rejected', 
        'Withdrawn'
    ) DEFAULT 'Draft',
    locked BOOLEAN DEFAULT FALSE,
    o_application_updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,
    o_application_updated_by INT,

    FOREIGN KEY (applicant_id) 
        REFERENCES Applicants(applicant_id),
    FOREIGN KEY (o_application_updated_by)
        REFERENCES Users(user_id),
    FOREIGN KEY (job_vacancy_id) 
        REFERENCES JobVacancies(job_vacancy_id)
);

CREATE TABLE RequirementTypes 
(
    requirement_type_id INT AUTO_INCREMENT PRIMARY KEY,
    requirement_type_name VARCHAR(100),
    o_requirement_type_added_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    o_requirement_type_added_by INT,

    FOREIGN KEY (o_requirement_type_added_by)
        REFERENCES Users(user_id)
);

INSERT INTO RequirementTypes
(requirement_type_name)
VALUES
('Curriculum Vitae'), 
('Valid Government ID'), 
('Transcript of Records'),
('Police Clearance'),
('Application Letter');

CREATE TABLE ApplicantDocuments 
(
    applicant_document_id INT AUTO_INCREMENT PRIMARY KEY,
    application_id INT,
    requirement_type_id INT,
    document_status ENUM('Submitted','Missing'),
    o_file_path TEXT,
    o_document_uploaded_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,

    FOREIGN KEY (application_id) 
        REFERENCES Applications(application_id),
    FOREIGN KEY (requirement_type_id) 
        REFERENCES RequirementTypes(requirement_type_id)
);

CREATE TABLE ScreeningResults 
(
    screening_id INT AUTO_INCREMENT PRIMARY KEY,
    application_id INT UNIQUE,
    screening_result ENUM('Qualified','Not Qualified'),
    remarks TEXT,
    screened_by INT,
    o_screen_updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,

    FOREIGN KEY (application_id)
        REFERENCES Applications(application_id),
    FOREIGN KEY (screened_by)
        REFERENCES Users(user_id)
);

CREATE TABLE InterviewTypes 
(
    interview_type_id INT AUTO_INCREMENT PRIMARY KEY,
    interview_type_name VARCHAR(100),
    o_interview_type_added_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    o_interview_type_added_by INT,

    FOREIGN KEY (o_interview_type_added_by) 
        REFERENCES Users(user_id)
);

CREATE TABLE InterviewSchedules 
(
    interview_schedule_id INT AUTO_INCREMENT PRIMARY KEY,
    application_id INT UNIQUE,
    interview_type_id INT,
    interview_date_time TIMESTAMP,
    interviewer INT,
    mode_location VARCHAR(100),
    status ENUM(
        'Scheduled',
        'Completed',
        'Cancelled'
    ) DEFAULT 'Scheduled',
    o_schedule_updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,
    o_schedule_updated_by INT,

    FOREIGN KEY (application_id) 
        REFERENCES Applications(application_id),
    FOREIGN KEY (interview_type_id) 
        REFERENCES InterviewTypes(interview_type_id),
    FOREIGN KEY (interviewer)
        REFERENCES Users(user_id),
    FOREIGN KEY (o_schedule_updated_by)
        REFERENCES Users(user_id)
);

CREATE TABLE InterviewEvaluations 
(
    interview_evaluation_id INT AUTO_INCREMENT PRIMARY KEY,
    application_id INT UNIQUE,
    interview_score INT,
    interview_remarks TEXT,
    interview_evaluation_result ENUM('Pass','Fail'),
    recommendations TEXT,
    o_evaluation_updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,
    o_evaluation_updated_by INT,

    FOREIGN KEY (application_id) 
        REFERENCES Applications(application_id),
    FOREIGN KEY (o_evaluation_updated_by)
        REFERENCES Users(user_id)
);

CREATE TABLE AssessmentTypes 
(
    assessment_type_id INT AUTO_INCREMENT PRIMARY KEY,
    assessment_type VARCHAR(100),
    o_assessment_type_added_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,
    o_assessment_type_added_by INT,

    FOREIGN KEY (o_assessment_type_added_by)
        REFERENCES Users(user_id)
);

CREATE TABLE AssessmentScores
(
    assessment_score_id INT AUTO_INCREMENT PRIMARY KEY,
    application_id INT UNIQUE,
    assessment_score INT,
    assessment_remarks TEXT,
    assessment_result ENUM('Pass','Fail'),
    o_assessment_created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,
    o_assessment_created_by INT,

    FOREIGN KEY (application_id) 
        REFERENCES Applications(application_id),
    FOREIGN KEY (o_assessment_created_by)
        REFERENCES Users(user_id)
);

CREATE TABLE HiringDecisions 
(
    hiring_decision_id INT AUTO_INCREMENT PRIMARY KEY,
    application_id INT UNIQUE,
    final_decision ENUM('Accepted','Rejected', 'On Hold'),
    final_remarks TEXT,
    o_final_decision_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,
    o_final_decision_by INT,

    FOREIGN KEY (application_id) 
        REFERENCES Applications(application_id),
    FOREIGN KEY (o_final_decision_by) 
        REFERENCES Users(user_id)
);

CREATE TABLE ApplicationStatusHistory 
(
    history_id INT AUTO_INCREMENT PRIMARY KEY,
    application_id INT,
    old_status ENUM(
        'Draft', 
        'Submitted',
        'Under Review', 
        'Shortlisted',
        'For Interview', 
        'For Assessment',
        'For Final Review', 
        'Accepted',
        'Rejected', 
        'Withdrawn'),
    new_status ENUM(
        'Draft', 
        'Submitted',
        'Under Review', 
        'Shortlisted',
        'For Interview', 
        'For Assessment',
        'For Final Review', 
        'Accepted',
        'Rejected', 
        'Withdrawn'),
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,
    updated_by INT,

    FOREIGN KEY (application_id) 
        REFERENCES Applications(application_id),
    FOREIGN KEY (updated_by) 
        REFERENCES Users(user_id)
);

CREATE TABLE AuditTrail 
(
    audit_trail_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    action VARCHAR(100),
    affected_table ENUM(
        'Departments',
        'Job Vacancies', 
        'Applications', 
        'Screening Results',
        'Interview Types',
        'Interview Schedules', 
        'Interview Evaluations', 
        'Assessment Types',
        'Assessment Scores',
        'Hiring Decisions'),
    affected_record_id INT,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,

    FOREIGN KEY (user_id) 
        REFERENCES Users(user_id)
);

