#include <fstream>
#include <cstdint>
#include <string>

#define global_var    static
#define local_persist static
#define internal_func static

#define cast(c, type) static_cast<##type>(c)

using int8 = int8_t;
using int16 = int16_t;
using int32 = int32_t;
using int64 = int64_t;

using uint8 = uint8_t;
using uint16 = uint16_t;
using uint32 = uint32_t;
using uint64 = uint64_t;
using uint = uint32;

using float32 = float;
using float64 = double;

struct String {
	const char* data = nullptr;
	int64 length = 0;

	String() = default;
	String(const char* str) {
		data = _strdup(str);
		length = strlen(str);
	}

};

struct Vector3D {
	float32 x = 0.0f, y = 0.0f, z = 0.0f;
};

struct SceneData {
	int32 objectCount = -1;
	String names[256];
	Vector3D positions[256];
};

bool saveToFile(const String filename, SceneData objList) {
	std::ofstream fileStream(filename.data, std::ios::out | std::ios::binary);
	if(!fileStream.is_open()) return false;

	for(int i = 0; i < objList.objectCount; ++i) {
		std::string line = "O:";
		line += objList.names[i].data;
		if(!(fileStream << line)) return false;
		fileStream << '\n';

		line = "P:" + std::to_string(objList.positions[i].x) + " " + std::to_string(objList.positions[i].y) + " " + std::to_string(objList.positions[i].z);
		if(!(fileStream << line)) return false;
		fileStream << '\n';
	}

	fileStream.close();
	return true;

}

bool loadFromFile(const String filename, SceneData* data) {
	std::ifstream fileStream(filename.data, std::ios::in | std::ios::binary);
	if(!fileStream.is_open()) return false;

	const uint16 lineBufferSize = 256;
	char lineBuffer[lineBufferSize];

	int32 objectCount = -1;
	while(!fileStream.eof()) {
		fileStream.getline(lineBuffer, lineBufferSize);
		if(lineBuffer[0] == 'O') {
			char name[lineBufferSize-2];
			const bool success = sscanf_s(lineBuffer, "O:%s\n", name, lineBufferSize-2);
			if(!success) return false;
			data->names[++objectCount] = String(name);
		}
		else if(lineBuffer[0] == 'P') {
			Vector3D vec;
			const bool success = sscanf_s(lineBuffer, "P:%f %f %f\n", &vec.x, &vec.y, &vec.z);
			if(!success) return false;
			data->positions[objectCount] = vec;
		}
	}

	data->objectCount = objectCount + 1;
	fileStream.close();
	return true;
}

int main() {

	const String filename("C:/Users/Daniel/AppData/LocalLow/DefaultCompany/GameEngineDesign_A1/SceneDLL.bin");
	SceneData data = {};
	if(!loadFromFile(filename, &data)) {
		printf("FAILED!");
	}
	else {
		printf("Read from %s:\n\n", filename.data);
		printf("Object count: %d\n", data.objectCount);
		for(int i = 0; i < data.objectCount; ++i) {
			printf("%s: (%f, %f, %f)\n",
				data.names[i].data,
				cast(data.positions[i].x, float64),
				cast(data.positions[i].y, float64),
				cast(data.positions[i].z, float64));
		}
	}
	
	getchar();
	return 0;
	
}