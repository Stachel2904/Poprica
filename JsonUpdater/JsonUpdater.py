newEnum = [
        "NONE",
        "STRAIGHT",
        "RIGHTTURN",
        "LEFTTURN",
        "TCROSS",
        "INTERSECTION",
        "ENTRY",
        " jkdfv vkjbf",
        "jjj",
        "kajakjsk",

        "STRAIGHTSIGN",
        "RIGHTTURNSIGN",
        "LEFTTURNSIGN",
        "TCROSSSIGNMAINLEFT",
        "TRCOSSSIGNMAINRIGHT"
    
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

with open ("test.txt", "r") as file:
    data = file.read().replace("\t", "").replace("\n", "")
    file.close()
    
foundIndex = 0
    
while (foundIndex != -1):
    foundIndex = data.find('"Type" : ', foundIndex, len(data))
    
    if (foundIndex == -1):
        break
    
    endOfReplace = data.find(',', foundIndex)
    
    print(oldEnum[int(data[foundIndex+8:endOfReplace])])
    
    data = data[: foundIndex+8] + str(newEnum.index(oldEnum[int(data[foundIndex+8:endOfReplace])])) + data[endOfReplace:]
    
with open ("test1.txt", "w") as newFile:
    newFile.write(data)
