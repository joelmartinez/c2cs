#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"

if [[ ! -z "$1" ]]; then
    RID="$1"
    if [[ -z "$RID" ]]; then
        echo "Runtime identifier not specified."
    fi
fi

dotnet publish $DIR/src/cs/production/C2CS/C2CS.csproj \
--output $DIR/publish/$RID \
--configuration Release \
--runtime $RID \
--no-self-contained \
'/property:PublishSingleFile=true' \
'/property:DebugType=embedded' \
'/property:IncludeNativeLibrariesForSelfExtract=true' \
'/property:GenerateDocumentationFile=false'