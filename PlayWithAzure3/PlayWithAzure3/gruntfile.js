module.exports = function(grunt) {

  // Project configuration.
  grunt.initConfig({
    pkg: grunt.file.readJSON('package.json'),
    uglify: {
      options: {
        banner: '/*! <%= pkg.name %> <%= grunt.template.today("yyyy-mm-dd") %> */\n',
		compress: true,
		preserveComments: false,
		mangle: true
      },
      libs: {
        src: 'libs/libs.js',
        dest: 'libs/libs.min.js'
      },
	  myApp: {
		  src: 'src/playWithAzure3.js',
		  dest: 'src/playWithAzure3.min.js'
	  }
    },
	concat: {
		options: {			
		},
		libs: {
			src: ['scripts/angular.min.js',
        'scripts/angular-animate.min.js',
        'scripts/angular-route.min.js',
        'scripts/angular-gettext.min.js',
        'scripts/typescript.min.js',
        'scripts/underscore.min.js',
        'scripts/jquery-2.1.4.min.js',
        'scripts/bootstrap.min.js'],
			dest: 'libs/libs.js'			
		},
		myApp: {
			src: ['app/*.js'],
			dest: 'src/playWithAzure3.js'
		}
	}
  });

  // Load the plugin that provides the "uglify" task.
  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-concat');

  // Default task(s).
  grunt.registerTask('default', ['concat', 'uglify']);

};