var gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    browserify = require("gulp-browserify");

var paths = {
    scripts: ['main.js', "modules/*.js", "modules/**/*.js", "modules/**/*.html"]
};

gulp.task('scripts', function () {
    // Minify and copy all JavaScript (except vendor scripts)
    // with sourcemaps all the way down
    return gulp.src(['main.js'])
        .pipe(browserify())
        //.pipe(uglify())
        .pipe(gulp.dest('build'));
});


// Rerun the task when a file changes
gulp.task('watch', ["scripts"], function () {
    gulp.watch(paths.scripts, ['scripts']);
    gulp.watch(paths.images, ['images']);
});

// The default task (called when you run `gulp` from cli)
gulp.task('default', ['watch']);