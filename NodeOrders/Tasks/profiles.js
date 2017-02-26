var gulp = require('gulp'),
    watch = require('gulp-watch'),
    runSequence = require('run-sequence');

gulp.task('publish',
    function() {
        runSequence('minify-img', 'favicon', 'js', 'sass', 'css', 'css-nano');
    });

gulp.task('watch',
    function() {
        gulp.watch([
                './src/scss/*.scss',
                './src/scss/*/*.scss',
            ],
            function() {
                runSequence('sass', 'css', 'css-nano');
            });
        gulp.watch([
                './src/javascripts/*.scss',
            ],
            function() {
                runSequence('js');
            });
    });

gulp.task('dev',
    function() {
        runSequence('sass', 'css', 'css-nano', 'js');
    });