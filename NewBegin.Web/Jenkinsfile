pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/helorten/NewBegin.git'
            }
        }
        stage('Restore Dependencies') {
            steps {
                sh 'dotnet restore'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test --configuration Release'
            }
        }
        stage('Publish') {
            steps {
                sh 'dotnet publish --configuration Release --output ./publish'
            }
        }
    }

    post {
        success {
            echo 'Build and Publish completed successfully!'
        }
        failure {
            echo 'Build or Publish failed.'
        }
    }
}
