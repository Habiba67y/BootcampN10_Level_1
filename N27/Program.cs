using N27;

var dbContext = new EFCoreContext();
Person peerson = new Person("Admin", 18, "Admin@gmail.com");
dbContext.people.Add(peerson);
dbContext.SaveChanges();