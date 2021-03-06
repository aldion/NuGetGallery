﻿using System;
using System.IO;
using System.Web.Mvc;

namespace NuGetGallery
{
    public class PackageFileService : IPackageFileService
    {
        readonly IConfiguration configuration;
        readonly IFileStorageService fileStorageSvc;

        public PackageFileService(
            IConfiguration configuration,
            IFileStorageService fileStorageSvc)
        {
            this.configuration = configuration;
            this.fileStorageSvc = fileStorageSvc;
        }

        string BuildFileName(
            string id, 
            string version)
        {
            return string.Format(Const.PackageFileSavePathTemplate, id, version, Const.PackageFileExtension);
        }

        public ActionResult CreateDownloadPackageActionResult(Package package)
        {
            if (package == null)
                throw new ArgumentNullException("package");
            if (package.PackageRegistration == null 
                || string.IsNullOrWhiteSpace(package.PackageRegistration.Id) 
                || string.IsNullOrWhiteSpace(package.Version))
                throw new ArgumentException("The package is missing required data.", "package");
            
            var fileName = BuildFileName(
                package.PackageRegistration.Id,
                package.Version);

            return fileStorageSvc.CreateDownloadFileActionResult(
                Const.PackagesFolderName, 
                fileName);
        }

        public void DeletePackageFile(
            string id, 
            string version)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("id");
            if (string.IsNullOrWhiteSpace(version))
                throw new ArgumentNullException("version");

            var fileName = BuildFileName(id, version);

            fileStorageSvc.DeleteFile(
                Const.PackagesFolderName, 
                fileName);
        }

        public void SavePackageFile(
            Package package,
            Stream packageFile)
        {
            if (package == null)
                throw new ArgumentNullException("package");
            if (packageFile == null)
                throw new ArgumentNullException("packageFile");
            if (package.PackageRegistration == null 
                || string.IsNullOrWhiteSpace(package.PackageRegistration.Id) 
                || string.IsNullOrWhiteSpace(package.Version))
                throw new ArgumentException("The package is missing required data.", "package");

            var fileName = BuildFileName(
                package.PackageRegistration.Id,
                package.Version);

            fileStorageSvc.SaveFile(
                Const.PackagesFolderName, 
                fileName, 
                packageFile);
        }
    }
}