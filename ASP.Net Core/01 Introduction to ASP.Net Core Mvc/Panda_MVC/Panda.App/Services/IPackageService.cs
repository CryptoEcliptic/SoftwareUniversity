using Panda.App.Domains;
using Panda.App.Models.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.App.Services
{
    public interface IPackageService
    {
        bool CreatePackage(PackageCreateBindingModel bindingModel);
    }
}
