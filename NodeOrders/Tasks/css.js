var gulp = require('gulp'),
    cssnano = require('gulp-cssnano');
printSpaceSavings = require('gulp-print-spacesavings'),
    sourcemaps = require('gulp-sourcemaps'),
    autoprefixer = require('autoprefixer'),
    postcss = require('gulp-postcss');;

gulp.task('css',
    function() {
        return gulp.src('./wwwroot/css/*.css')
            .pipe(sourcemaps.init())
            .pipe(postcss([
                autoprefixer(
                {
                    browsers: [
                        'Chrome 50',
                        'Firefox 12',
                        'Explorer 8',
                        'Explorer 9',
                        'Explorer 10',
                        'Explorer 11',
                        'Edge 12',
                        'ExplorerMobile 11',
                        'Safari 5',
                        'iOS 6',
                        'Opera 35'
                    ]
                })
            ]))
            .pipe(printSpaceSavings.init())
            .pipe(printSpaceSavings.print())
            .pipe(gulp.dest('./wwwroot/css'));
    });