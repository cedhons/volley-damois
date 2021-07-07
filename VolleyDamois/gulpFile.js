/// <binding AfterBuild='clean, mincss, minimage, minjs' />
'use strict';

var gulp = require('gulp'),
    concat = require('gulp-concat'),
    cssmin = require('gulp-cssmin'),
    uglify = require('gulp-uglify'),
    imagemin = require('gulp-imagemin'),
    del = require('del');

var webrootFolder = 'wwwroot';
var paths = { webroot: "./" + webrootFolder + "/" };
paths.js = paths.webroot + "js/**/*.js";
paths.css = paths.webroot + "css/**/*.css";
paths.image = paths.webroot + "img/**/*.*";
paths.mylib = paths.webroot + "minlib";

gulp.task("clean", function () { return del.sync(paths.mylib + "/*") });
gulp.task("minjs", function () { return gulp.src(paths.js).pipe(concat("all.min.js")).pipe(uglify()).pipe(gulp.dest(paths.mylib)) });
gulp.task("mincss", function () { return gulp.src(paths.css).pipe(concat("style.css")).pipe(cssmin()).pipe(gulp.dest(paths.mylib)) });
gulp.task("minimage", function () { return gulp.src(paths.image).pipe(imagemin()).pipe(gulp.dest(paths.mylib)) });