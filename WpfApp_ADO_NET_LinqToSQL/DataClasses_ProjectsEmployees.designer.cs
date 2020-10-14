﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp_ADO_NET_LinqToSQL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="WpfApp_ADO_NET_CodeFirst.Model_ProjectsEmployees")]
	public partial class DataClasses_ProjectsEmployeesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertEmployees(Employees instance);
    partial void UpdateEmployees(Employees instance);
    partial void DeleteEmployees(Employees instance);
    partial void InsertProjectEmployees(ProjectEmployees instance);
    partial void UpdateProjectEmployees(ProjectEmployees instance);
    partial void DeleteProjectEmployees(ProjectEmployees instance);
    partial void InsertProjects(Projects instance);
    partial void UpdateProjects(Projects instance);
    partial void DeleteProjects(Projects instance);
    #endregion
		
		public DataClasses_ProjectsEmployeesDataContext() : 
				base(global::WpfApp_ADO_NET_LinqToSQL.Properties.Settings.Default.WpfApp_ADO_NET_CodeFirst_Model_ProjectsEmployeesConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses_ProjectsEmployeesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses_ProjectsEmployeesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses_ProjectsEmployeesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses_ProjectsEmployeesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Employees> Employees
		{
			get
			{
				return this.GetTable<Employees>();
			}
		}
		
		public System.Data.Linq.Table<ProjectEmployees> ProjectEmployees
		{
			get
			{
				return this.GetTable<ProjectEmployees>();
			}
		}
		
		public System.Data.Linq.Table<Projects> Projects
		{
			get
			{
				return this.GetTable<Projects>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetEmployeerWithAgeLess", IsComposable=true)]
		public IQueryable<GetEmployeerWithAgeLessResult> GetEmployeerWithAgeLess([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> st)
		{
			return this.CreateMethodCallQuery<GetEmployeerWithAgeLessResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), st);
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetProjectWithMaxEmployees", IsComposable=true)]
		public IQueryable<GetProjectWithMaxEmployeesResult> GetProjectWithMaxEmployees()
		{
			return this.CreateMethodCallQuery<GetProjectWithMaxEmployeesResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetEmployeerWithLastNameLengthMoreOrEqual", IsComposable=true)]
		public IQueryable<GetEmployeerWithLastNameLengthMoreOrEqualResult> GetEmployeerWithLastNameLengthMoreOrEqual([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> st)
		{
			return this.CreateMethodCallQuery<GetEmployeerWithLastNameLengthMoreOrEqualResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), st);
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Employees")]
	public partial class Employees : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _FirstName;
		
		private string _LastName;
		
		private int _Age;
		
		private string _Address;
		
		private string _FotoPath;
		
		private EntitySet<ProjectEmployees> _ProjectEmployees;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnAgeChanging(int value);
    partial void OnAgeChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnFotoPathChanging(string value);
    partial void OnFotoPathChanged();
    #endregion
		
		public Employees()
		{
			this._ProjectEmployees = new EntitySet<ProjectEmployees>(new Action<ProjectEmployees>(this.attach_ProjectEmployees), new Action<ProjectEmployees>(this.detach_ProjectEmployees));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(MAX)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(MAX)")]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int NOT NULL")]
		public int Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this.OnAgeChanging(value);
					this.SendPropertyChanging();
					this._Age = value;
					this.SendPropertyChanged("Age");
					this.OnAgeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(MAX)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FotoPath", DbType="NVarChar(MAX)")]
		public string FotoPath
		{
			get
			{
				return this._FotoPath;
			}
			set
			{
				if ((this._FotoPath != value))
				{
					this.OnFotoPathChanging(value);
					this.SendPropertyChanging();
					this._FotoPath = value;
					this.SendPropertyChanged("FotoPath");
					this.OnFotoPathChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employees_ProjectEmployees", Storage="_ProjectEmployees", ThisKey="Id", OtherKey="EmployeeId")]
		public EntitySet<ProjectEmployees> ProjectEmployees
		{
			get
			{
				return this._ProjectEmployees;
			}
			set
			{
				this._ProjectEmployees.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ProjectEmployees(ProjectEmployees entity)
		{
			this.SendPropertyChanging();
			entity.Employees = this;
		}
		
		private void detach_ProjectEmployees(ProjectEmployees entity)
		{
			this.SendPropertyChanging();
			entity.Employees = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ProjectEmployees")]
	public partial class ProjectEmployees : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ProjectId;
		
		private int _EmployeeId;
		
		private EntityRef<Employees> _Employees;
		
		private EntityRef<Projects> _Projects;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProjectIdChanging(int value);
    partial void OnProjectIdChanged();
    partial void OnEmployeeIdChanging(int value);
    partial void OnEmployeeIdChanged();
    #endregion
		
		public ProjectEmployees()
		{
			this._Employees = default(EntityRef<Employees>);
			this._Projects = default(EntityRef<Projects>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ProjectId
		{
			get
			{
				return this._ProjectId;
			}
			set
			{
				if ((this._ProjectId != value))
				{
					if (this._Projects.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProjectIdChanging(value);
					this.SendPropertyChanging();
					this._ProjectId = value;
					this.SendPropertyChanged("ProjectId");
					this.OnProjectIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmployeeId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int EmployeeId
		{
			get
			{
				return this._EmployeeId;
			}
			set
			{
				if ((this._EmployeeId != value))
				{
					if (this._Employees.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEmployeeIdChanging(value);
					this.SendPropertyChanging();
					this._EmployeeId = value;
					this.SendPropertyChanged("EmployeeId");
					this.OnEmployeeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employees_ProjectEmployees", Storage="_Employees", ThisKey="EmployeeId", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Employees Employees
		{
			get
			{
				return this._Employees.Entity;
			}
			set
			{
				Employees previousValue = this._Employees.Entity;
				if (((previousValue != value) 
							|| (this._Employees.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Employees.Entity = null;
						previousValue.ProjectEmployees.Remove(this);
					}
					this._Employees.Entity = value;
					if ((value != null))
					{
						value.ProjectEmployees.Add(this);
						this._EmployeeId = value.Id;
					}
					else
					{
						this._EmployeeId = default(int);
					}
					this.SendPropertyChanged("Employees");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Projects_ProjectEmployees", Storage="_Projects", ThisKey="ProjectId", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Projects Projects
		{
			get
			{
				return this._Projects.Entity;
			}
			set
			{
				Projects previousValue = this._Projects.Entity;
				if (((previousValue != value) 
							|| (this._Projects.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Projects.Entity = null;
						previousValue.ProjectEmployees.Remove(this);
					}
					this._Projects.Entity = value;
					if ((value != null))
					{
						value.ProjectEmployees.Add(this);
						this._ProjectId = value.Id;
					}
					else
					{
						this._ProjectId = default(int);
					}
					this.SendPropertyChanged("Projects");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Projects")]
	public partial class Projects : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Title;
		
		private System.DateTime _StartDate;
		
		private System.DateTime _EndDate;
		
		private string _Description;
		
		private EntitySet<ProjectEmployees> _ProjectEmployees;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnStartDateChanging(System.DateTime value);
    partial void OnStartDateChanged();
    partial void OnEndDateChanging(System.DateTime value);
    partial void OnEndDateChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public Projects()
		{
			this._ProjectEmployees = new EntitySet<ProjectEmployees>(new Action<ProjectEmployees>(this.attach_ProjectEmployees), new Action<ProjectEmployees>(this.detach_ProjectEmployees));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(MAX)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL")]
		public System.DateTime StartDate
		{
			get
			{
				return this._StartDate;
			}
			set
			{
				if ((this._StartDate != value))
				{
					this.OnStartDateChanging(value);
					this.SendPropertyChanging();
					this._StartDate = value;
					this.SendPropertyChanged("StartDate");
					this.OnStartDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EndDate", DbType="DateTime NOT NULL")]
		public System.DateTime EndDate
		{
			get
			{
				return this._EndDate;
			}
			set
			{
				if ((this._EndDate != value))
				{
					this.OnEndDateChanging(value);
					this.SendPropertyChanging();
					this._EndDate = value;
					this.SendPropertyChanged("EndDate");
					this.OnEndDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(MAX)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Projects_ProjectEmployees", Storage="_ProjectEmployees", ThisKey="Id", OtherKey="ProjectId")]
		public EntitySet<ProjectEmployees> ProjectEmployees
		{
			get
			{
				return this._ProjectEmployees;
			}
			set
			{
				this._ProjectEmployees.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ProjectEmployees(ProjectEmployees entity)
		{
			this.SendPropertyChanging();
			entity.Projects = this;
		}
		
		private void detach_ProjectEmployees(ProjectEmployees entity)
		{
			this.SendPropertyChanging();
			entity.Projects = null;
		}
	}
	
	public partial class GetEmployeerWithAgeLessResult
	{
		
		private string _FirstName;
		
		private string _LastName;
		
		public GetEmployeerWithAgeLessResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(MAX)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this._FirstName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(MAX)")]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this._LastName = value;
				}
			}
		}
	}
	
	public partial class GetProjectWithMaxEmployeesResult
	{
		
		private int _Id;
		
		private string _Title;
		
		public GetProjectWithMaxEmployeesResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL")]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(MAX)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
	}
	
	public partial class GetEmployeerWithLastNameLengthMoreOrEqualResult
	{
		
		private string _FirstName;
		
		private string _LastName;
		
		public GetEmployeerWithLastNameLengthMoreOrEqualResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(MAX)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this._FirstName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(MAX)")]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this._LastName = value;
				}
			}
		}
	}
}
#pragma warning restore 1591