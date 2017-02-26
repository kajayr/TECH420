/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/
var gulp = require('gulp'),
    runSequence = require('run-sequence');


gulp.task('default',
    function() {
        runSequence('sass', 'css');
    });