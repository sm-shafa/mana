﻿using ManaCoreWebApplication.App.Command;
using ManaCoreWebApplication.Models;

namespace ManaCoreWebApplication.App.Profile;

public class Profile: AutoMapper.Profile
{
    public Profile()
    {
        CreateMap<AddOrModifyCategoryCommand, Category>();
        CreateMap<CreateOrUpdateProductCommand, Product>();
    }
}