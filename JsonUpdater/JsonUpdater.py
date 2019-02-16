newEnum = [
        "NONE",
        "STRAIGHT",
        "TURN",
        "TCROSS",
        "INTERSECTION",
        "ENTRY",

        "STRAIGHTSIGN",
        "RIGHTTURNSIGN",
        "LEFTTURNSIGN",
        "TCROSSSIGNMAINLEFT",
        "TRCOSSSIGNMAINRIGHT",
    
        "CONSTRUCTIONSIGN",
        "ROOM",
        "ROOMWALL",
        "ROOMCORNER",
        "ROOMEXIT",
        "PRISONERROOM"
]

oldEnum = [
        "NONE",
        "STRAIGHT",
        "RIGHTTURN",
        "LEFTTURN",
        "TCROSS",
        "INTERSECTION",
        "ENTRY",

        "STRAIGHTSIGN",
        "RIGHTTURNSIGN",
        "LEFTTURNSIGN",
        "TCROSSSIGNMAINLEFT",
    
        "CONSTRUCTIONSIGN",
        "ROOM",
        "ROOMWALL",
        "ROOMCORNER",
        "ROOMEXIT",
        "PRISONERROOM"
]

with open ("Floortest.json", "r") as file:
    data = file.read().replace("\t", "").replace("\n", "")
    file.close()
    
foundIndex = 0
    
while (foundIndex != -1):
    foundIndex = data.find('"Type" : ', foundIndex, len(data))
    
    if (foundIndex == -1):
        break
    
    endOfReplace = data.find(',', foundIndex)
    
    print(oldEnum[int(data[foundIndex+8:endOfReplace])])


    ##diesen Teil wegen Vereinen von zwei Tiles
    search = "";

    if (oldEnum[int(data[foundIndex+8:endOfReplace])] == "RIGHTTURN" or oldEnum[int(data[foundIndex+8:endOfReplace])] == "LEFTTURN"):
        search = "TURN";
    else:
        search = oldEnum[int(data[foundIndex+8:endOfReplace])]

    ####
    
    data = data[: foundIndex+8] + str(newEnum.index(search)) + data[endOfReplace:]
    
with open ("test1.json", "w") as newFile:
    newFile.write(data)
