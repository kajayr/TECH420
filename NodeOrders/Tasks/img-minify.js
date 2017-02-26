var gulp = require('gulp'),
    imagemin = require('gulp-imagemin'),
    printSpaceSavings = require('gulp-print-spacesavings');

gulp.task('minify-img',
    function() {
        return gulp.src('./src/images/*')
            .pipe(printSpaceSavings.init())
            .pipe(imagemin({
                progressive: true
            }))
            .pipe(printSpaceSavings.print())
            .pipe(gulp.dest('./wwwroot/images/'));
    });