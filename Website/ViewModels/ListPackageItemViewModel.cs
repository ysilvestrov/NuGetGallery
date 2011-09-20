﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace NuGetGallery {
    public class ListPackageItemViewModel : PackageViewModel {
        public ListPackageItemViewModel(Package package)
            : base(package) {
            Tags = package.Tags != null ? package.Tags.Trim().Split(' ') : null;
            Authors = package.Authors;
            Owners = package.PackageRegistration.Owners;
        }
        public IEnumerable<PackageAuthor> Authors { get; set; }
        public ICollection<User> Owners { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public bool IsOwner(IPrincipal user) {
            if (user == null || user.Identity == null) {
                return false;
            }
            return Owners.Any(u => u.Username == user.Identity.Name);
        }
    }
}