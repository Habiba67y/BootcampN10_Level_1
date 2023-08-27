using N32_T3;

var productService = ProductService.GetInstance();
productService.Add("Name1", "Description1");
productService.Add("Name2", "Description2");
productService.Add("Name3", "Description3");
productService.Add("Name4", "Description4");
productService.Add("", "");
productService.Clone(productService.products[0].Id);
productService.Display();

