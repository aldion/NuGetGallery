﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.WindowsAzure.StorageClient;
using Moq;
using Xunit;
using Xunit.Extensions;

namespace NuGetGallery
{
    public class CloudBlobFileStorageServiceFacts
    {
        public class TheCtor
        {
            [Theory]
            [FolderNamesData]
            public void WillCreateABlobContainerForAllFoldersIfTheyDoNotExist(string folderName)
            {
                var fakeBlobClient = new Mock<ICloudBlobClient>();
                var fakeBlobContainer = new Mock<ICloudBlobContainer>();
                fakeBlobClient.Setup(x => x.GetContainerReference(It.IsAny<string>())).Returns(fakeBlobContainer.Object);
                
                var service = CreateService(fakeBlobClient: fakeBlobClient);

                fakeBlobClient.Verify(x => x.GetContainerReference(folderName));
                fakeBlobContainer.Verify(x => x.CreateIfNotExist());
            }

            [Theory]
            [FolderNamesData(includePermissions: true)]
            public void WillSetPermissionsForAllFolderBlobContainers(
                string folderName, 
                bool isPublic)
            {
                var fakeBlobClient = new Mock<ICloudBlobClient>();
                var fakeBlobContainer = new Mock<ICloudBlobContainer>();
                fakeBlobClient.Setup(x => x.GetContainerReference(It.IsAny<string>())).Returns(fakeBlobContainer.Object);

                var service = CreateService(fakeBlobClient: fakeBlobClient);

                fakeBlobClient.Verify(x => x.GetContainerReference(folderName));
                fakeBlobContainer.Verify(x => x.SetPermissions(It.Is<BlobContainerPermissions>(p => p.PublicAccess == (isPublic ? BlobContainerPublicAccessType.Blob : BlobContainerPublicAccessType.Off))));
            }
        }
        
        public class TheCreateDownloadPackageResultMethod
        {
            [Theory]
            [FolderNamesData]
            public void WillGetTheBlobFromTheCorrectFolderContainer(string folderName)
            {
                var fakeBlobClient = new Mock<ICloudBlobClient>();
                var fakeBlobContainer = new Mock<ICloudBlobContainer>();
                var fakeBlob = new Mock<ICloudBlob>();
                fakeBlobClient.Setup(x => x.GetContainerReference(It.IsAny<string>()))
                    .Returns<string>(container => 
                    {
                        if (container == folderName)
                            return fakeBlobContainer.Object;
                        else
                            return new Mock<ICloudBlobContainer>().Object; 
                    });
                fakeBlobContainer.Setup(x => x.GetBlobReference(It.IsAny<string>())).Returns(fakeBlob.Object);
                fakeBlob.Setup(x => x.Uri).Returns(new Uri("http://theUri"));
                var service = CreateService(fakeBlobClient: fakeBlobClient);

                service.CreateDownloadFileActionResult(folderName, "theFileName");

                fakeBlobContainer.Verify(x => x.GetBlobReference("theFileName"));
            }

            [Fact]
            public void WillReturnARedirectResultToTheBlobUri()
            {
                var fakeBlobClient = new Mock<ICloudBlobClient>();
                var fakeBlobContainer = new Mock<ICloudBlobContainer>();
                var fakeBlob = new Mock<ICloudBlob>();
                fakeBlobClient.Setup(x => x.GetContainerReference(It.IsAny<string>())).Returns(fakeBlobContainer.Object);
                fakeBlobContainer.Setup(x => x.GetBlobReference(It.IsAny<string>())).Returns(fakeBlob.Object);
                fakeBlob.Setup(x => x.Uri).Returns(new Uri("http://theUri"));
                var service = CreateService(fakeBlobClient: fakeBlobClient);

                var result = service.CreateDownloadFileActionResult(Const.PackagesFolderName, "theFileName") as RedirectResult;

                Assert.NotNull(result);
                Assert.Equal("http://theuri/", result.Url);
            }
        }

        public class TheDeletePackageFileMethod
        {
            [Theory]
            [FolderNamesData]
            public void WillGetTheBlobFromTheCorrectFolderContainer(string folderName)
            {
                var fakeBlobClient = new Mock<ICloudBlobClient>();
                var fakeBlobContainer = new Mock<ICloudBlobContainer>();
                var fakeBlob = new Mock<ICloudBlob>();
                fakeBlobClient.Setup(x => x.GetContainerReference(It.IsAny<string>()))
                    .Returns<string>(container =>
                    {
                        if (container == folderName)
                            return fakeBlobContainer.Object;
                        else
                            return new Mock<ICloudBlobContainer>().Object;
                    });
                fakeBlobContainer.Setup(x => x.GetBlobReference(It.IsAny<string>())).Returns(fakeBlob.Object);
                fakeBlob.Setup(x => x.Uri).Returns(new Uri("http://theUri"));
                var service = CreateService(fakeBlobClient: fakeBlobClient);

                service.DeleteFile(folderName, "theFileName");

                fakeBlobContainer.Verify(x => x.GetBlobReference("theFileName"));
            }

            [Fact]
            public void WillDeleteTheBlobIfItExists()
            {
                var fakeBlobClient = new Mock<ICloudBlobClient>();
                var fakeBlobContainer = new Mock<ICloudBlobContainer>();
                var fakeBlob = new Mock<ICloudBlob>();
                fakeBlobClient.Setup(x => x.GetContainerReference(It.IsAny<string>())).Returns(fakeBlobContainer.Object);
                fakeBlobContainer.Setup(x => x.GetBlobReference(It.IsAny<string>())).Returns(fakeBlob.Object);
                fakeBlob.Setup(x => x.Uri).Returns(new Uri("http://theUri"));
                var service = CreateService(fakeBlobClient: fakeBlobClient);

                service.DeleteFile(Const.PackagesFolderName, "theFileName");

                fakeBlob.Verify(x => x.DeleteIfExists());
            }
        }

        public class TheSavePackageFileMethod
        {
            [Theory]
            [FolderNamesData]
            public void WillGetTheBlobFromTheCorrectFolderContainer(string folderName)
            {
                var fakeBlobClient = new Mock<ICloudBlobClient>();
                var fakeBlobContainer = new Mock<ICloudBlobContainer>();
                var fakeBlob = new Mock<ICloudBlob>();
                fakeBlobClient.Setup(x => x.GetContainerReference(It.IsAny<string>()))
                   .Returns<string>(container =>
                   {
                       if (container == folderName)
                           return fakeBlobContainer.Object;
                       else
                           return new Mock<ICloudBlobContainer>().Object;
                   });
                fakeBlobContainer.Setup(x => x.GetBlobReference(It.IsAny<string>())).Returns(fakeBlob.Object);
                fakeBlob.Setup(x => x.Uri).Returns(new Uri("http://theUri"));
                var service = CreateService(fakeBlobClient: fakeBlobClient);

                service.SaveFile(folderName, "theFileName", new MemoryStream());

                fakeBlobContainer.Verify(x => x.GetBlobReference("theFileName"));
            }

            [Fact]
            public void WillDeleteTheBlobIfItExists()
            {
                var fakeBlobClient = new Mock<ICloudBlobClient>();
                var fakeBlobContainer = new Mock<ICloudBlobContainer>();
                var fakeBlob = new Mock<ICloudBlob>();
                fakeBlobClient.Setup(x => x.GetContainerReference(It.IsAny<string>())).Returns(fakeBlobContainer.Object);
                fakeBlobContainer.Setup(x => x.GetBlobReference(It.IsAny<string>())).Returns(fakeBlob.Object);
                fakeBlob.Setup(x => x.Uri).Returns(new Uri("http://theUri"));
                var service = CreateService(fakeBlobClient: fakeBlobClient);

                service.SaveFile(Const.PackagesFolderName, "theFileName", new MemoryStream());

                fakeBlob.Verify(x => x.DeleteIfExists());
            }

            [Fact]
            public void WillUploadThePackageFileToTheBlob()
            {
                var fakeBlobClient = new Mock<ICloudBlobClient>();
                var fakeBlobContainer = new Mock<ICloudBlobContainer>();
                var fakeBlob = new Mock<ICloudBlob>();
                fakeBlobClient.Setup(x => x.GetContainerReference(It.IsAny<string>())).Returns(fakeBlobContainer.Object);
                fakeBlobContainer.Setup(x => x.GetBlobReference(It.IsAny<string>())).Returns(fakeBlob.Object);
                fakeBlob.Setup(x => x.Uri).Returns(new Uri("http://theUri"));
                var service = CreateService(fakeBlobClient: fakeBlobClient);
                var fakePackageFile = new MemoryStream();

                service.SaveFile(Const.PackagesFolderName, "theFileName", fakePackageFile);

                fakeBlob.Verify(x => x.UploadFromStream(fakePackageFile));
            }
        }

        class FolderNamesDataAttribute : DataAttribute
        {
            public FolderNamesDataAttribute(bool includePermissions = false)
            {
                IncludePermissions = includePermissions;
            }
            
            public override IEnumerable<object[]> GetData(
                MethodInfo methodUnderTest, 
                Type[] parameterTypes)
            {
                var folderNames = new List<object[]> 
                {
                    new object[] { Const.PackagesFolderName, true }
                };

                if (!IncludePermissions)
                    folderNames = folderNames.Select(fn => new object[] { fn.ElementAt(0) }).ToList();

                return folderNames;
            }

            public bool IncludePermissions { get; set; }
        }

        static CloudBlobFileStorageService CreateService(
            Mock<ICloudBlobClient> fakeBlobClient = null)
        {
            if (fakeBlobClient == null)
                fakeBlobClient = new Mock<ICloudBlobClient>();
            
            return new CloudBlobFileStorageService(fakeBlobClient.Object);
        }
    }
}
