'use strict';
angular.module('demoModule', ['angularFileUpload']).controller('demoCtrl', ['$scope', '$http', 'FileUploader', function ($scope, $http, FileUploader) {

    $scope.reportOptions = {};


        var uploader = $scope.uploader = new FileUploader({
           
            url: 'http://localhost:17508/api/PdfToExcelConvert/UploadZIP/?k=' + document.getElementById("UserId").value
        });

        //$scope.upload = function () {
        //    alert(1);
        //    if (document.getElementById('UPLOADZIP').files[0] == null) {
        //       // $scope.saveRecord();

        //    }
        //    else {

        //        var fd = new FormData();
        //        fd.append("_data", document.getElementById('UPLOADZIP').files[0]);

        //        $http(
        //          {
        //              url: 'http://localhost:52312/api/PdfToExcelConvert/UploadZIP/', // _url + "/UploadZIP/?EMP_CODE=" + $scope.EMPLOYEES.EMP_CODE,
        //              method: "POST",
        //              headers: { 'Content-Type': undefined },
        //              transformRequest: angular.identity,
        //              data: fd,
        //          }
        //          ).success(function (response) {
        //              //$scope.Uploadfile = response[0];
        //              //$scope.EMPLOYEES.UPLOADZIP = $scope.Uploadfile;
        //              //$scope.EMPLOYEES.ORG_UPLOADZIP = response[1];
        //              //$scope.saveRecord();

        //          })
        //    }


        //}


        // FILTERS

        // a sync filter
        uploader.filters.push({
            name: 'syncFilter',
            fn: function (item /*{File|FileLikeObject}*/, options) {
                console.log('syncFilter');
                return this.queue.length < 10;
            }
        });

        // an async filter
        uploader.filters.push({
            name: 'asyncFilter',
            fn: function (item /*{File|FileLikeObject}*/, options, deferred) {
                console.log('asyncFilter');
                setTimeout(deferred.resolve, 1e3);
            }
        });

        // CALLBACKS

        uploader.onWhenAddingFileFailed = function (item /*{File|FileLikeObject}*/, filter, options) {
            console.info('onWhenAddingFileFailed', item, filter, options);
        };
        uploader.onAfterAddingFile = function (fileItem) {
            console.info('onAfterAddingFile', fileItem);
        };
        uploader.onAfterAddingAll = function (addedFileItems) {
            console.info('onAfterAddingAll', addedFileItems);
        };
        uploader.onBeforeUploadItem = function (item) {
            console.info('onBeforeUploadItem', item);
        };
        uploader.onProgressItem = function (fileItem, progress) {
            console.info('onProgressItem', fileItem, progress);
        };
        uploader.onProgressAll = function (progress) {
            console.info('onProgressAll', progress);
        };
        uploader.onSuccessItem = function (fileItem, response, status, headers) {
            //alert(1);
            console.info('onSuccessItem', fileItem, response, status, headers);
        };
        uploader.onErrorItem = function (fileItem, response, status, headers) {
            console.info('onErrorItem', fileItem, response, status, headers);
        };
        uploader.onCancelItem = function (fileItem, response, status, headers) {
            console.info('onCancelItem', fileItem, response, status, headers);
        };
        uploader.onCompleteItem = function (fileItem, response, status, headers) {
            console.info('onCompleteItem', fileItem, response, status, headers);
        };
        uploader.onCompleteAll = function () {
            console.info('onCompleteAll');
        };

        console.info('uploader', uploader);
    }]);



//// Defining angularjs module
//'use strict';
//var app = angular.module('demoModule',['angularFileUpload'], []);

//// Defining angularjs Controller and injecting ProductsService
//app.controller('demoCtrl', ['$scope', 'FileUploader', function ($scope, $http, FileUploader) {
//    var uploader = $scope.uploader = new FileUploader({
//        url: 'api/PdfToExcelConvert/PostProduct/'
//    });

//    // FILTERS

//    // a sync filter
//    uploader.filters.push({
//        name: 'syncFilter',
//        fn: function (item /*{File|FileLikeObject}*/, options) {
//            console.log('syncFilter');
//            return this.queue.length < 10;
//        }
//    });

//    // an async filter
//    uploader.filters.push({
//        name: 'asyncFilter',
//        fn: function (item /*{File|FileLikeObject}*/, options, deferred) {
//            console.log('asyncFilter');
//            setTimeout(deferred.resolve, 1e3);
//        }
//    });

//    // CALLBACKS

//    uploader.onWhenAddingFileFailed = function (item /*{File|FileLikeObject}*/, filter, options) {
//        console.info('onWhenAddingFileFailed', item, filter, options);
//    };
//    uploader.onAfterAddingFile = function (fileItem) {
//        console.info('onAfterAddingFile', fileItem);
//    };
//    uploader.onAfterAddingAll = function (addedFileItems) {
//        console.info('onAfterAddingAll', addedFileItems);
//    };
//    uploader.onBeforeUploadItem = function (item) {
//        console.info('onBeforeUploadItem', item);
//    };
//    uploader.onProgressItem = function (fileItem, progress) {
//        console.info('onProgressItem', fileItem, progress);
//    };
//    uploader.onProgressAll = function (progress) {
//        console.info('onProgressAll', progress);
//    };
//    uploader.onSuccessItem = function (fileItem, response, status, headers) {
//        console.info('onSuccessItem', fileItem, response, status, headers);
//    };
//    uploader.onErrorItem = function (fileItem, response, status, headers) {
//        console.info('onErrorItem', fileItem, response, status, headers);
//    };
//    uploader.onCancelItem = function (fileItem, response, status, headers) {
//        console.info('onCancelItem', fileItem, response, status, headers);
//    };
//    uploader.onCompleteItem = function (fileItem, response, status, headers) {
//        console.info('onCompleteItem', fileItem, response, status, headers);
//    };
//    uploader.onCompleteAll = function () {
//        console.info('onCompleteAll');
//    };

//    console.info('uploader', uploader);
    
//}]);
