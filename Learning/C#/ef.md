## Entity Framework

- OMR - Object Relational Mapper
  * querying
  * change traking
  * saving
  * concurrency
  * transactions
  * caching
  * built-in convensions
  * configurations
  * migrations

## Setup

* For the project containing DbContext
  * `install-package Microsoft.EntityFrameworkCore`
  * `install-package Microsoft.EntityFrameworkCore.Tools`
  * `install-package Microsoft.EntityFrameworkCore.SqlServer`

*  For the startup project:
  * `install-package Microsoft.EntityFrameworkCore.Design`

* For VSCode
  * Go to nuget.org and get ef tools: `dotnet tool install --global dotnet-ef --version 5.0.2`

* Create MyDbContext : DbContext
* In appsettings.json add:

        "ConnectionStrings": {
            "DefaultConnection": "Server=.\\sqlexpress;Database=StudioWeb_TypeCache;User ID=sa;Password=1qazXSW@;"
        }
* `add-migration MigrationName` or `dotnet ef migrations add MigrationName`
* `update-database [TargetMigration]` or `dotnet ef database update [TargetMigration]`


## Attributes

* Should not be mixed with Fluent API
* Should be avoided in large projects.
* `[Table("TableName", Schema = "CatalogName" )]`
* `[Column("ColumnName")]`
* `[Key]` `[DatabaseGenerated(DatabaseGeneratedOption.None)]`
* Composite Primary Keys: 

        [Key]
        [Column(Order = 1)]
        public int Key1 { get; set; }

        [Key]
        [Column(Order = 2)]
        public int Key2 { get; set; }

* `[DatabaseGenerated(DatabaseGeneratedOption.None/Identity/Computed)]`
* `[Required]`
* `[MaxLength(255)]`
* `[Index(IsUnique = true)]`
* `[ForeignKey("AuthorId")]`

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }


## Fluent API

* Preferred over Attributes.

* DbContext.OnModelCreating:

  1. Using modelBuilder.Entity

                modelBuilder.Entity<Property>(option =>
                {
                  option.HasKey(p => new { p.Id1, p.Id2 });
                  option.Property(p => p.Name)
                        .IsRequired()
                        .HasMaxLength(255);
                });

                // One-to-many Relationship
                Entity<Author>.HasMany(a => a.Courses)
                              .WithOne(c => c.Author)
                              .HasForeignKey(c => c.AuthorId);

                // Many-to-many Relationship
                Entity<Course>.HasMany(c => c.Tags)
                              .WithMany(t => t.Courses)
                              .Map(m =>
                                      {
                                        m.ToTable("CourseTag");
                                        m.MapLeftKey("CourseId");
                                        m.MapRightKey("TagId");
                                      });

                // One-to-zero/one Relationship
                Entity<Course>.HasOptional(c => c.Caption)
                              .WithRequired(c => c.Course);

                // One-to-one Relationship
                Entity<Course>.HasRequired(c => c.Cover)
                              .WithRequiredPrincipal(c => c.Course);

                Entity<Cover>.HasRequired(c => c.Course)
                             .WithRequiredDependent(c => c.Cover);

  2. Using IEntityTypeConfiguration

          
                modelBuilder.ApplyConfiguration(new PropertyConfiguration());

                public class PropertyConfiguration : IEntityTypeConfiguration<Property>

## LINQ

* Restriction

        context.Courses.Where(c => c.Level == 1);

* Projection

        context.Courses.Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name });

        // Flattens hierarchical lists
        var tags = context.Courses.SelectMany(c => c.Tags);

* Grouping

        var groups = context.Courses.GroupBy(c => c.Level);

* Inner Join

Use when there is no relationship between your entities and you need to link them based on a key.

        var authors = context.Authors.Join(context.Courses,
                                           a => a.Id,  // key on the left side
                                           c => c.AuthorId, // key on the right side,
                                           (author, course) => // what to do once matched 
                                           new { AuthorName = author.Name, CourseName = course.Name } );

* Group Join

Useful when you need to group objects by a property and count the number of objects in each
group. In SQL we do this with LEFT JOIN, COUNT(*) and GROUP BY. In LINQ, we use group join.

        var authors = context.Authors.GroupJoin(context.Courses,
                                                a => a.Id, // key on the left side
                                                c => c.AuthorId, // key on the right side,
                                                (author, courses) => // what to do once matched
                                                new { AuthorName = author.Name, Courses = courses });

* Cross Join

To get full combinations of all objects on the left and the ones on the right.

        var combos = context.Authors.SelectMany(a => context.Courses,
                                                (author, course) => new  { AuthorName = author.Name, CourseName = course.Name });

* Partitioning

To get records in a given page.

        context.Courses.Skip(10).Take(10);

* Element Operators

        context.Courses.First(c => c.Level == 1);
        context.Courses.Single(c => c.Id == 1);
        context.Courses.Load(1);

* Quantifying

        bool allInLevel1 = context.Courses.All(c => c.Level == 1);
        bool anyInLevel1 = context.Courses.Any(c => c.Level == 1);

* Aggregating

        int count = context.Courses.Count(c => c.Level == 1);
        int min = context.Courses.Min(c => c.Price);
        int max = context.Courses.Max(c => c.Price);
        int avarage = context.Courses.Average(c => c.Price);
        int sum = context.Courses.Sum(c => c.Price);

## Loading

* Lazy loading - declare related objects as virtual
  - disadvantages - more trips to the database, not suitable for web applications.

* Eager loading 

        context.Courses.Include(c => c.Authors).ThenInclude(a => a.Address);
        context.Courses.Include(c => c.Authors.Select(a => a.Address));
        context.Authors.Include(a => a.Address.Location));

* Explicit loading 
        
        context.Cources.Where(c => c.AuthorId == author.Id && c.price == 0)
                       .Load();


## Repository Pattern

* IRepository
  - is like a collection: Add, AddRange, Remove, RemoveRange, Get, Find, GetAll
  - returns IEnumerable instead of IQueryable, do not allow clients to build queries.
* IUnitOfWork
  - properties for repositories.
  - Save method.




## Tools for Debug

* Microsoft Sql Server Server Management Studio
  * Tools / Sql Profiler - inspect queries run on the database.

* LINQPad - app used to run LINQ code 
