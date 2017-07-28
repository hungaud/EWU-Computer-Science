#ifndef UTILS_H
#define UTILS_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

/**
 * Strips the carriage return from the String passed in
 */
void strip(char * array);

/**
 * Converts the String to all uppercase
 */
void toUppercaseString(char * array);

/**
 * Converts the String to all lowercase
 */
void toLowercaseString(char * array);

/**
 * Strips the carriage return from the input buffer
 */
void stripInputBuffer(FILE * fin);


#endif
