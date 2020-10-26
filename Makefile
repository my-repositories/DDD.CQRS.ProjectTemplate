t: test
test: c u b i n

c: clean
clean:
	rm -rf test-results/*

u: uninstall
uninstall:
	dotnet new -u DDD.CQRS.ProjectTemplate

b: build
build:
	dotnet pack -c Release

i: install
install:
	dotnet new -i $$(pwd)/bin/Release/DDD.CQRS.ProjectTemplate.1.0.0.nupkg

n: new
new:
	(cd test-results && dotnet new ddd.cqrs -in -p=Cool.ProjectX)
