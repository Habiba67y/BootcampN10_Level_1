﻿namespace ToDoList.Models;

public class FilterPagination
{
    public int PageSize { get; set; } = 20;
    public int PageToken { get; set; } = 1;
}
