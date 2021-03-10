DROP FROM [hod].[dbo].[Groups]

CREATE TABLE [hod].[dbo].[Groups]
(
	group_id int PRIMARY KEY,
	group_name NVARCHAR(10),
	startYear datetime,
	qualif_id int FOREIGN KEY Groups_FK_qualif REFERENCES [hod].[dbo].[Qualifications](qualif_id),
	educForm_id int FOREIGN KEY Groups_FK_educFocm REFERENCES [hod].[dbo].[EducForms](educForm_id),
	dep_id int FOREIGN KEY Groups_FK_dep REFERENCES [hod].[dbo].[Departments](dep_id)
)


