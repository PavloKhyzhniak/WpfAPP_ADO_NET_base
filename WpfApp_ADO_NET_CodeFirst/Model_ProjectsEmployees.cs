namespace WpfApp_ADO_NET_CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class Model_ProjectsEmployees : DbContext
    {
        // Контекст настроен для использования строки подключения "Model_ProjectsEmployees" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "WpfApp_ADO_NET_CodeFirst.Model_ProjectsEmployees" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Model_ProjectsEmployees" 
        // в файле конфигурации приложения.
        public Model_ProjectsEmployees()
            : base("name=Model_ProjectsEmployees")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
       // public virtual DbSet<ProjectEmployees> ProjectEmployees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        //    base.OnModelCreating(modelBuilder);
        //
        //    modelBuilder.Entity<ProjectEmployees>()
        //        .HasKey(c => new { c.Project_ProjectId, c.Employee_EmployeeId });
                
            modelBuilder.Entity<Project>()
                .HasMany<Employee>(c => c.Employees)
                .WithMany(r => r.Projects)
                          .Map(ru =>
                          {
                              ru.MapLeftKey("ProjectId");
                              ru.MapRightKey("EmployeeId");
                              ru.ToTable("ProjectEmployees");
                          });


//            modelBuilder.Entity<Project>()
//                .HasMany(c => c.Employees)
//                .WithRequired()
//                .HasForeignKey(c => c.EmployeeId);
//
//            modelBuilder.Entity<Employee>()
//                .HasMany(c => c.Projects)
//                .WithRequired()
//                .HasForeignKey(c => c.ProjectId);
        }
    }

    public class Project
    {
        [Key]
        [Column("Id")]
        public int ProjectId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }

    public class Employee
    {
        [Key]
        [Column("Id")]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string FotoPath { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }

   // public class ProjectEmployees
   // {
   //     public int Project_ProjectId { get; set; }
   //     public int Employee_EmployeeId { get; set; }
   // }
}