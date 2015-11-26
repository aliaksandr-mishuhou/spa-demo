var gulp = require("gulp");
var mainBowerFiles = require("main-bower-files");
var rename = require("gulp-rename");
var print = require('gulp-print');

var paths = {
    thirdPartyJs: "Scripts/libs",
    thirdPartyCss: "Content/css",
    thirdPartyFonts: "Content/fonts",
    bowerComponents: "bower_components"
};

gulp.task("main-bower-files", function copyMainBowerFilesToAssets() {
    return gulp.src(mainBowerFiles(), { base: paths.bowerComponents })
        .pipe(print())
        .pipe(rename(function (path) {
            path.dirname = "";
        }))
        .pipe(gulp.dest(paths.thirdPartyJs))
        .pipe(print());
});

//Set a default tasks
gulp.task('default', ['main-bower-files'], function () { });