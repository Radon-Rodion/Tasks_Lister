#include"pch.h"
#include <iostream>
#include <windows.h>
#include <conio.h>
#include <tlhelp32.h>
#include <psapi.h>
#include "WtsApi32.h"
#pragma comment(lib, "WtsApi32.lib")

#include "TaskLister.h"

#define MAX_PROC_NAME_LENGTH 30
#define MAX_NUMBER_LENGTH 12

void getResourceUsage(ProcessInfo* info);
float systemTimeToSeconds(SYSTEMTIME sysTime);
char* WideStringToAnsi(wchar_t* str);
ProcessInfo* defineProcInfo(WTS_PROCESS_INFO pWPI);
ProcessInfo** getProcessesInfo(long* nProcessesPtr);

void* getProcInfoTable() {
    long nProcsPtr = 0;
    ProcessInfo** procInfos = getProcessesInfo(&nProcsPtr);
    char*** table = (char***)calloc(nProcsPtr, sizeof(char**));
    double cpuTotalUsage = 0;
    double totalMem = 0;
    for (int i = 1; i < nProcsPtr; i++) {
        cpuTotalUsage += procInfos[i]->cpuUsage;
        totalMem += procInfos[i]->memory;

        table[i-1] = (char**)calloc(5, sizeof(char*));
        table[i-1][0] = WideStringToAnsi(procInfos[i]->procName);
        for (int j = 1; j < 5; j++)
            table[i-1][j] = (char*)calloc(MAX_NUMBER_LENGTH, sizeof(char));
        sprintf_s(table[i-1][1], MAX_NUMBER_LENGTH, "%5d", procInfos[i]->pid);
        sprintf_s(table[i - 1][2], MAX_NUMBER_LENGTH, "%10.2f", procInfos[i]->cpuTime);
        sprintf_s(table[i - 1][3], MAX_NUMBER_LENGTH, "%10.2f", procInfos[i]->cpuUsage);
        sprintf_s(table[i - 1][4], MAX_NUMBER_LENGTH, "%10.2f", procInfos[i]->memory);
    }
    table[nProcsPtr-1] = (char**)calloc(5, sizeof(char*));
    for (int j = 1; j < 5; j++)
        table[nProcsPtr - 1][j] = (char*)calloc(MAX_NUMBER_LENGTH, sizeof(char));

    table[nProcsPtr - 1][0] = nullptr;
    sprintf_s(table[nProcsPtr - 1][1], MAX_NUMBER_LENGTH, "%5d", nProcsPtr-1);
    table[nProcsPtr - 1][2] = nullptr;
    sprintf_s(table[nProcsPtr - 1][3], MAX_NUMBER_LENGTH, "%.2f", cpuTotalUsage);
    sprintf_s(table[nProcsPtr - 1][4], MAX_NUMBER_LENGTH, "%.2f", totalMem);

    return (void*)table;
}

ProcessInfo** getProcessesInfo(long* nProcessesPtr) {
    WTS_PROCESS_INFO* pWPIs = NULL;
    DWORD dwProcCount = 0;
    ProcessInfo** procInfos = nullptr;

    if (WTSEnumerateProcessesW(WTS_CURRENT_SERVER_HANDLE, NULL, 1, &pWPIs, &dwProcCount))
    {
        procInfos = (ProcessInfo**)calloc(dwProcCount, sizeof(ProcessInfo*));
        for (DWORD i = 0; i < dwProcCount; i++) {
            procInfos[i] = defineProcInfo(pWPIs[i]);
        }
    }

    /*if (pWPIs)
    {
        WTSFreeMemory(pWPIs);
    }*/
    *nProcessesPtr = ((long)dwProcCount);

    return procInfos;
}

ProcessInfo* defineProcInfo(WTS_PROCESS_INFO pWPI) {
    ProcessInfo* info = new ProcessInfo();
    info->pid = pWPI.ProcessId;
    info->procName = pWPI.pProcessName;
    getResourceUsage(info);
    return info;
}

void getResourceUsage(ProcessInfo* info) {
    HANDLE hProc = OpenProcess(PROCESS_ALL_ACCESS, FALSE, info->pid);
    FILETIME createTime;
    FILETIME exitTime;
    FILETIME kernelTime;
    FILETIME userTime;
    if (GetProcessTimes(hProc,
        &createTime, &exitTime, &kernelTime, &userTime) != -1)
    {
        SYSTEMTIME createSystemTime;
        SYSTEMTIME exitSystemTime;
        SYSTEMTIME kernelSystemTime;
        SYSTEMTIME userSystemTime;
        if (FileTimeToSystemTime(&userTime, &userSystemTime) != -1 && FileTimeToSystemTime(&kernelTime, &kernelSystemTime) != -1
            && FileTimeToSystemTime(&createTime, &createSystemTime) != -1 && FileTimeToSystemTime(&exitTime, &exitSystemTime) != -1)
        {
            float userT = systemTimeToSeconds(userSystemTime);
            float kernelT = systemTimeToSeconds(kernelSystemTime);
            float createT = systemTimeToSeconds(createSystemTime);
            float exitT = systemTimeToSeconds(exitSystemTime);
            if (createT - exitT > 0) {
                info->cpuTime = userT + kernelT;
                info->cpuUsage = info->cpuTime / (createT - exitT) * 100;
                PROCESS_MEMORY_COUNTERS_EX pmc;
                GetProcessMemoryInfo(hProc, (PROCESS_MEMORY_COUNTERS*)&pmc, sizeof(pmc));
                info->memory = (float)pmc.WorkingSetSize*1.5f / (1024l * 1024);
            }
            else {
                info->cpuTime = 0;
                info->cpuUsage = 0;
            }
        }

    }

}

float systemTimeToSeconds(SYSTEMTIME sysTime) {
    return (float)sysTime.wHour * 3600 + (float)sysTime.wMinute * 60 +
        (float)sysTime.wSecond + (float)sysTime.wMilliseconds / 1000.0;
}

char* WideStringToAnsi(wchar_t* str) //перевод
{
    char* res = (char*)calloc(MAX_PROC_NAME_LENGTH, sizeof(char));
    int i;
    for (i = 0; i < MAX_PROC_NAME_LENGTH && str[i] != '\0'; i++) {
        res[i] = str[i];
    }
    res[i] = '\0';
    return res;
}
