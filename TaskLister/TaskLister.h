#pragma once

#ifdef TASKLISTER_EXPORTS
#define TASKLISTER_API __declspec(dllexport)
#else
#define TASKLISTER_API __declspec(dllimport)
#endif

struct ProcessInfo {
    long pid;
    wchar_t* procName;
    float cpuTime;
    float cpuUsage;
    float memory;
};
typedef struct ProcessInfo ProcessInfo;

extern "C" TASKLISTER_API void* getProcInfoTable();