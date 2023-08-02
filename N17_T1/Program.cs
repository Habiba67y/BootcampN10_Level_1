using N17_T1;

var ets1 = new EmailTemplateService();
ets1.Add("Account Registration", "Hurmatli {{User}}, ushbu xabar sizni muvafaqqiyatli ro'yxatdan o'tganligingizni bildirish uchun yuborildi");
ets1.Add("Account Blocked", "Hurmatli {{User}}, ushbu xabar sizni akkountingiz bloklanganini bildirish uchun yuborildi");
ets1.GetRegistrationTemplate("Habiba");
ets1.GetAccountBlockedTemplate("Habiba");
var ets2 = new EmailTemplateService();
ets2.Add("Account Registration", "Hurmatli {{User}}, ushbu xabar sizni muvafaqqiyatli ro'yxatdan o'tganligingizni bildirish uchun yuborildi");
ets2.Add("Account Blocked", "Hurmatli {{User}}, ushbu xabar sizni akkountingiz bloklanganini bildirish uchun yuborildi");
ets2.GetRegistrationTemplate("Parizoda");
ets2.GetAccountBlockedTemplate("Parizoda");
