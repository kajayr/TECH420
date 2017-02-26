var gulp = require('gulp'),
    favicons = require('gulp-favicons'),
    gutil = require('gulp-util');

gulp.task('favicon',
    function() {
        return gulp.src('./src/images/logo.png').pipe(favicons({
                appName: null, // Your application's name. `string`
                appDescription: null, // Your application's description. `string`
                developerName: 'Richard Sperry', // Your (or your developer's) name. `string`
                developerURL: null, // Your (or your developer's) URL. `string`
                background: '#fff', // Background colour for flattened icons. `string`
                path: '/images/favicon', // Path for overriding default icons path. `string`
                display: 'browser', // Android display: "browser" or "standalone". `string`
                orientation: 'portrait', // Android orientation: "portrait" or "landscape". `string`
                start_url: '/', // Android start application's URL. `string`
                version: '1.0', // Your application's version number. `number`
                logging: false, // Print logs to console? `boolean`
                online: false, // Use RealFaviconGenerator to create favicons? `boolean`
                preferOnline: false, // Use offline generation, if online generation has failed. `boolean`
                icons: {
                    android: true, // Create Android homescreen icon. `boolean`
                    appleIcon: true, // Create Apple touch icons. `boolean` or `{ offset: offsetInPercentage }`
                    appleStartup: true, // Create Apple startup images. `boolean`
                    coast: { offset: 25 },
// Create Opera Coast icon with offset 25%. `boolean` or `{ offset: offsetInPercentage }`
                    favicons: true, // Create regular favicons. `boolean`
                    firefox: true, // Create Firefox OS icons. `boolean` or `{ offset: offsetInPercentage }`
                    windows: true, // Create Windows 8 tile icons. `boolean`
                    yandex: true // Create Yandex browser icon. `boolean`
                },
                html: 'favicon.html', // The file name with the html that is required for every device
                pipeHTML: true,
                replace: true

            }))
            .on('error', gutil.log)
            .pipe(gulp.dest('./images/favicon'));
    });