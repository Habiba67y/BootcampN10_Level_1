using N14_HT2_CL;

var ucl = new UltimateClassroomAttendance();
ucl.Mark("Sattorova Habiba", true);
ucl.Mark("Togayeva Parizoda", true);
ucl.Mark("Shavqiyeva Sevinch", false, "Kasal bo'ldi");
ucl.Mark("Rustamova Muslima", false, "Safarga ketdi");
ucl.Mark("G'ishmat", true);
ucl.Display();