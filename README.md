# SimplePersistence.Model.EF
Model specific implementations and helpers for the Entity Framework

## Installation
This library can be installed via NuGet package. Just run the following command:

```powershell
Install-Package SimplePersistence.Model.EF
```

## Usage

```csharp
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
	base.OnModelCreating(modelBuilder);

	#region Logging

	modelBuilder.Entity<Models.Logging.Application>(cfg =>
	{
		cfg.HasKey(e => e.Id)
			.Property(e => e.Id).HasMaxLength(64);
		cfg.Property(e => e.Description).IsRequired().HasMaxLength(512);
		cfg.HasMany(e => e.Logs).WithRequired(e => e.Application);

		cfg.MapCreatedMeta().MapUpdatedMeta().MapDeletedMeta().MapByteArrayVersion();
	}, "Applications", "Logging");

	modelBuilder.Entity<Models.Logging.Level>(cfg =>
	{
		cfg.HasKey(e => e.Id)
			.Property(e => e.Id).HasMaxLength(8);
		cfg.Property(e => e.Description).IsRequired().HasMaxLength(512);
		cfg.HasMany(e => e.Logs).WithRequired(e => e.Level);

		cfg.MapCreatedMeta().MapUpdatedMeta().MapDeletedMeta().MapByteArrayVersion();
	}, "Levels", "Logging");

	modelBuilder.Entity<Models.Logging.Log>(cfg =>
	{
		cfg.HasIdentityKeyAsLong();
		cfg.Property(e => e.CreatedOn).IsRequired().AddIndex();
		cfg.Property(e => e.LevelId).IsRequired().HasMaxLength(8)
		  .HasColumnName("Level");
		cfg.Property(e => e.Logger).IsRequired().HasMaxLength(256);
		cfg.Property(e => e.Message).IsRequired();
		cfg.Property(e => e.Exception).IsOptional();
		cfg.Property(e => e.CreatedBy).IsRequired().HasMaxLength(128);
		cfg.Property(e => e.MachineName).IsOptional().HasMaxLength(128);
		cfg.Property(e => e.ApplicationId).IsRequired().HasMaxLength(64)
			.HasColumnName("Application");
		cfg.Property(e => e.AssemblyVersion).IsOptional().HasMaxLength(32).AddIndex();

		cfg.HasRequired(e => e.Level).WithMany(e => e.Logs).HasForeignKey(e => e.LevelId);
		cfg.HasRequired(e => e.Application).WithMany(e => e.Logs).HasForeignKey(e => e.ApplicationId);
	}, "Logs", "Logging");

	#endregion
}
```
