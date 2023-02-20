# Running a dotnet Spin app in Minikube using kwasm.sh and runwasi

Note: You can skip step 3, if you trust running the container I've made public on `ghcr.io/mikkelhegn/mydotnet:v1`

1. Install kwasm.sh with Minikube - https://kwasm.sh/quickstart/
1. Add the runtimeclass - `kubectl apply -f runtime-class.yaml`
1. Build the app and container, or skip ahead to 4
	- Spin app - `spin build -f c-sharp/spin.toml`
	- Build the container - `docker buildx build -t`_`some-container-registry/username`_`/mydotnet:v1 .`
	- Push it - `docker push`_`some-container-registry/username`_`/mydotnet:v1`
	- Change the container image reference in `spinapp.yaml`
1. Deploy the app to Minikube - `kubectl apply -f spinapp.yaml`
1. Port forward - `kubectl port-forward deployment/wasm-spin 8000:80`
1. Call the app endpoint - `curl localhost:8000/hello`
