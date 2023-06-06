cmake_minimum_required(VERSION 3.25)
project(Copyctor)

set(CMAKE_CXX_STANDARD 14)

include_directories(.)

add_executable(Copyctor
        main.cpp
        Vector.h)
