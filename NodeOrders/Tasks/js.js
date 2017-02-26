var gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    printSpaceSavings = require('gulp-print-spacesavings'),
    concat = require('gulp-concat');

gulp.task('js',
    function() {
        return gulp.src([
                './src/javascripts/*.js'
            ])
            .pipe(printSpaceSavings.init())
            .pipe(uglify())
            .pipe(printSpaceSavings.print())
            .pipe(concat('main.js'))
            .pipe(gulp.dest('./js'));
    });