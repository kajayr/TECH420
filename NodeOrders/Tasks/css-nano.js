/// <reference path="css-nano.js" />
var gulp = require('gulp');
var cssnano = require('gulp-cssnano'),
    rename = require('gulp-rename');

gulp.task('css-nano',
    function() {
        return gulp.src('./css/main.css')
            .pipe(cssnano())
            .pipe(rename({
                suffix: '.min'
            }))
            .pipe(gulp.dest('./css'));
    });