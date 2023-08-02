using N17_HT1;

var crm = new CarRentalManagement();
CarRental bmw1 = new Bmw("model name number one bmw");
CarRental bmw2 = new Bmw("model name number two bmw");
CarRental bmw3 = new Bmw("model name number three bmw");
CarRental audi1 = new Audi("model name number one audi");
CarRental audi2 = new Audi("model name number two audi");
CarRental audi3 = new Audi("model name number three audi");
crm.Add(bmw1);
crm.Add(bmw2);
crm.Add(bmw3);
crm.Add(audi1);
crm.Add(audi2);
crm.Add(audi3);
crm.Rent(bmw1.BrandName);
crm.Rent(bmw2.BrandName);
crm.Rent(audi1.BrandName);
crm.Rent(audi2.BrandName);
crm.Return(bmw2);
crm.Return(audi2);
crm.Return(bmw1); // nimagadir bmw1 va audi1 larda return ni 0 qilib qo'yyapti, misolni shartiga qarab qilishga harakat qildim
crm.Return(audi1);
crm.CalculateBalance();