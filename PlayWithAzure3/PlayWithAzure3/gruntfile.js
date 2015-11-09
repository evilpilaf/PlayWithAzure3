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
			src: ['scripts/*.min.js'],
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