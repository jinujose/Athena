pipeline {
	agent { label 'master' }
	
	stages {
		stage('Checkout') {
			steps {
				checkout scm
			}
		}
		
		stage('Restore PACKAGES') {
		   steps {
		    bat "dotnet restore --configfile NuGet.Config"
		   }
		  }
		  stage('Clean') {
		   steps {
		    bat 'dotnet clean'
		   }
		  }
		  stage('Build') {
		   steps {
		    bat 'dotnet build --configuration Release'
		   }
		  }
		  stage('Pack') {
		   steps {
		    bat 'dotnet pack --no-build --output nupkgs'
		   }
		  }
		  stage('Publish') {
		   steps {
		    bat "dotnet nuget push **\\nupkgs\\*.nupkg -k yourApiKey -s            http://myserver/artifactory/api/nuget/nuget-internal-stable/com/sample"
		   }
  }
	}
	post {
        failure {
            script {
                currentBuild.result = 'FAILURE'
            }
        }

        always {
            step([$class: 'Mailer',
                notifyEveryUnstableBuild: true,
                recipients: "{RECIPIENTS}",
                sendToIndividuals: true])
        }
    }
}
