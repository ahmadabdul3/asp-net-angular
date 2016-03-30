angular.module('mesjidApp')
.config(indexStates);


indexStates.$inject = ['$stateProvider', '$urlRouterProvider'];

function indexStates($stateProvider, $urlRouterProvider) {

    $stateProvider
	.state('members', {
	    url: '/members',
	    templateUrl: '/Angular/MesjidApp/Modules/Members/Index.html',
	    controller: 'mesjidIndexVM as mesjidIndexCtrl'
	})
    .state('member', {
        url: '/members/edit/{id}',
        templateUrl: '/Angular/MesjidApp/Modules/Member/Index.html',
        controller: 'EditMemberVM as editCtrl'
    })
    .state('addMember', {
        url: '/members/add',
        templateUrl: '/Angular/MesjidApp/Modules/AddMember/Index.html',
        controller: 'AddMemberVM as addCtrl'
    })
	//.state('projects', {
	//    url: '/projects',
	//    templateUrl: 'modules/_projectsModule/views/projects.html',
	//    controller: 'ProjectsController as projectCtl',
	//    resolve: {
	//        totalResourcesClass: function () { return 'hidden'; },
	//        resourceListClass: function () { return ''; },
	//        orderBy: function () { return 'name'; },
	//        mainLink: function () { return '#/projects/resources'; },
	//        mainLinkName: function () { return 'Project Resources'; }
	//    }
	//})
	//.state('projectsResourceCount', {
	//    url: '/projects/resources',
	//    templateUrl: 'modules/_projectsModule/views/projects.html',
	//    controller: 'ProjectsController as projectCtl',
	//    resolve: {
	//        totalResourcesClass: function () { return ''; },
	//        resourceListClass: function () { return 'hidden'; },
	//        orderBy: function () { return 'resourceLength'; },
	//        mainLink: function () { return '#/projects'; },
	//        mainLinkName: function () { return 'Projects'; }
	//    }
	//})
    ;
    $urlRouterProvider.otherwise('/members');


}