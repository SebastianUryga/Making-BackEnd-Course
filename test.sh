#!/bin/bash
projects=(Passenger.Tests Passenger.Tests.EndToEnd)
for project in ${projects[*]}
do
	echo Running test for: ${project}
	dotnet test ${project}/${project}.csproj
done

read -p "press enter to continue..."

