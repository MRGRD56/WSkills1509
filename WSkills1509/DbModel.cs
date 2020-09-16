namespace WSkills1509
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class DbModel : DbContext
	{
		public DbModel()
			: base("name=DbModel")
		{
		}

		public virtual DbSet<Models.Client> Clients { get; set; }
		public virtual DbSet<Models.Tag> Tags { get; set; }
		public virtual DbSet<Models.ClientTag> ClientTags { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Models.Client>()
				.Property(e => e.Gender)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<Models.Client>()
				.Property(e => e.FirstName)
				.IsUnicode(false);

			modelBuilder.Entity<Models.Client>()
				.Property(e => e.LastName)
				.IsUnicode(false);

			modelBuilder.Entity<Models.Client>()
				.Property(e => e.Patronymic)
				.IsUnicode(false);

			modelBuilder.Entity<Models.Client>()
				.Property(e => e.PhoneNumber)
				.IsUnicode(false);

			modelBuilder.Entity<Models.Client>()
				.Property(e => e.Email)
				.IsUnicode(false);

			modelBuilder.Entity<Models.Tag>()
				.Property(e => e.TagName)
				.IsUnicode(false);
		}
	}
}
